using Microsoft.Extensions.DependencyInjection;
using WeTicket.Application.Shared.Commands;
using WeTicket.Application.Shared.Queries;
using WeTicket.Domain.Events;

namespace WeTicket.Application.Shared.Dispatchers;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _provider;

    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
    {
        Type commandHandlerType = typeof(ICommandHandler<,>);
        Type typeResult = command.GetType().GetGenericArguments()[0];
        Type[] commandTypeArgs = [command.GetType(), typeResult];
        Type handlerType = commandHandlerType.MakeGenericType(commandTypeArgs);
        ICommandHandler<ICommand<TResult>, TResult> handler = (ICommandHandler<ICommand<TResult>, TResult>)_provider.GetRequiredService(handlerType);

        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        Type queryHandlerType = typeof(IQueryHandler<,>);
        Type typeResult = query.GetType().GetGenericArguments()[0];
        Type[] queryTypeArgs = [query.GetType(), typeResult];
        Type handlerType = queryHandlerType.MakeGenericType(queryTypeArgs);
        IQueryHandler<IQuery<TResult>, TResult> handler = (IQueryHandler<IQuery<TResult>, TResult>)_provider.GetRequiredService(handlerType);

        return await handler.HandleAsync(query, cancellationToken);
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