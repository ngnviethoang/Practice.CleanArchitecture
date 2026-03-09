using Microsoft.Extensions.DependencyInjection;
using WeTicket.Application.Shared.Common;
using WeTicket.Domain.Events;

namespace WeTicket.Application.Shared.Dispatchers;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _provider;

    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResult> DispatchAsync<TResult>(IRequest<TResult> command, CancellationToken cancellationToken = default)
    {
        Type requestHandlerType = typeof(IRequestHandler<,>);
        Type[] requestTypeArgs = [command.GetType(), typeof(TResult)];
        Type handlerType = requestHandlerType.MakeGenericType(requestTypeArgs);
        // TODO GetRequiredService by interface not handler class name
        IRequestHandler<IRequest<TResult>, TResult> handler = (IRequestHandler<IRequest<TResult>, TResult>)_provider.GetRequiredService(handlerType);

        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        Type domainEventHandlerType = typeof(IDomainEventHandler<>);
        Type[] domainEventTypeArgs = [domainEvent.GetType()];
        Type handlerType = domainEventHandlerType.MakeGenericType(domainEventTypeArgs);
        IDomainEventHandler<IDomainEvent> handler = (IDomainEventHandler<IDomainEvent>)_provider.GetRequiredService(handlerType);

        await handler.HandleAsync(domainEvent, cancellationToken);
    }
}