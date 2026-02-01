using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WeTicket.Contract.Logging;

namespace WeTicket.Domain.Infrastructure.Messaging;

public class MessageBus : IMessageBus
{
    private static readonly List<Type> _consumers = [];
    private static readonly Dictionary<string, List<Type>> _outboxMessageHandlers = new();
    private readonly ILogger<MessageBus> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MessageBus(IServiceProvider serviceProvider, ILogger<MessageBus> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task SendAsync<TData>(Message<TData> message, CancellationToken cancellationToken = default)
    {
        await _serviceProvider.GetRequiredService<IMessageSender<TData>>().SendAsync(message, cancellationToken);
    }

    public async Task ReceiveAsync<TConsumer, TData>(CancellationToken cancellationToken = default)
    {
        ILogger<IMessageReceiver<TConsumer, TData>> logger = _serviceProvider.GetRequiredService<ILogger<IMessageReceiver<TConsumer, TData>>>();

        await _serviceProvider.GetRequiredService<IMessageReceiver<TConsumer, TData>>().ReceiveAsync(
            async (data, token) =>
            {
                using Activity activity = ActivityExtensions.StartNew("HandleAsync", data.MetaData.ActivityId);
                using IServiceScope scope = _serviceProvider.CreateScope();

                long startingTimestamp = Stopwatch.GetTimestamp();

                foreach (Type handlerType in _consumers)
                {
                    bool canHandleEvent = handlerType.GetInterfaces()
                        .Any(x => x.IsGenericType
                                  && x.GetGenericTypeDefinition() == typeof(IMessageConsumer<,>)
                                  && x.GenericTypeArguments[0] == typeof(TConsumer) && x.GenericTypeArguments[1] == typeof(TData));

                    if (canHandleEvent)
                    {
                        IMessageConsumer<TConsumer, TData> handler = (IMessageConsumer<TConsumer, TData>)scope.ServiceProvider.GetRequiredService(handlerType);
                        await handler.HandleAsync(data, token);
                    }
                }

                TimeSpan stop = Stopwatch.GetElapsedTime(startingTimestamp);

                logger.LogInformation("{ConsumerType} handled {MessageType} in {ElapsedMilliseconds} ms.", typeof(TConsumer).Name, typeof(TData).Name, stop.TotalMilliseconds);
            }, cancellationToken);
    }

    public async Task ReceiveAsync<TConsumer, TData>(Func<Message<TData>, CancellationToken, Task> action, CancellationToken cancellationToken = default)
    {
        await _serviceProvider.GetRequiredService<IMessageReceiver<TConsumer, TData>>().ReceiveAsync(action, cancellationToken);
    }

    public async Task SendAsync(OutboxMessage message, CancellationToken cancellationToken = default)
    {
        string key = $"{message.EventSource}:{message.EventType}";
        List<Type>? handlerTypes = _outboxMessageHandlers.GetValueOrDefault(key);

        if (handlerTypes == null)
        {
            _logger.LogWarning("No handler found for {Source}:{Type}", message.EventSource, message.EventType);
            return;
        }

        foreach (Type type in handlerTypes)
        {
            IOutboxMessagePublisher handler = (IOutboxMessagePublisher)_serviceProvider.GetRequiredService(type);
            await handler.HandleAsync(message, cancellationToken);
        }
    }

    internal static void AddConsumers(Assembly assembly, IServiceCollection services)
    {
        List<Type> types = assembly.GetTypes()
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IMessageConsumer<,>)))
            .ToList();

        foreach (Type type in types)
        {
            services.AddTransient(type);
        }

        _consumers.AddRange(types);
    }

    internal static void AddOutboxMessagePublishers(Assembly assembly, IServiceCollection services)
    {
        List<Type> types = assembly.GetTypes()
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IOutboxMessagePublisher)))
            .ToList();

        foreach (Type type in types)
        {
            services.AddTransient(type);
        }

        foreach (Type item in types)
        {
            string[] canHandlerEventTypes = (string[])item.InvokeMember(nameof(IOutboxMessagePublisher.CanHandleEventTypes), BindingFlags.InvokeMethod, null, null, null, CultureInfo.CurrentCulture)!;
            string eventSource = (string)item.InvokeMember(nameof(IOutboxMessagePublisher.CanHandleEventSource), BindingFlags.InvokeMethod, null, null, null, CultureInfo.CurrentCulture)!;

            foreach (string eventType in canHandlerEventTypes)
            {
                string key = $"{eventSource}:{eventType}";

                if (!_outboxMessageHandlers.ContainsKey(key))
                {
                    _outboxMessageHandlers[key] = [];
                }

                _outboxMessageHandlers[key].Add(item);
            }
        }
    }
}