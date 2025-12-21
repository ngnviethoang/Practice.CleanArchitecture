using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleShop.Domain.Infrastructure.Messaging;

public class MessageBus : IMessageBus
{
    private readonly IServiceProvider _serviceProvider;
    private static List<Type> _consumers;

    public MessageBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    internal static void AddConsumers(Assembly assembly, IServiceCollection services)
    {
        var types = assembly.GetTypes()
            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IMessageConsumer<>)))
            .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type);
        }

        _consumers.AddRange(types);
    }

    public async Task SendAsync<TData>(Message<TData> message, CancellationToken cancellationToken = default)
    {
        await _serviceProvider.GetRequiredService<IMessageSender<TData>>().SendAsync(message, cancellationToken);
    }

    public async Task ReceiveAsync<TData>(CancellationToken cancellationToken = default)
    {
        // TODO Write implement
    }

    public async Task ReceiveAsync<TData>(Func<Message<TData>, CancellationToken, Task> action, CancellationToken cancellationToken = default)
    {
        await _serviceProvider.GetRequiredService<IMessageReceiver<TData>>().ReceiveAsync(action, cancellationToken);
    }
}