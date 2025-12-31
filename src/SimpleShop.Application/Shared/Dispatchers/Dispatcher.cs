using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Application.Shared.Commands;
using SimpleShop.Application.Shared.Queries;
using SimpleShop.Domain.Events;

namespace SimpleShop.Application.Shared.Dispatchers;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _provider;

    public Dispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = [command.GetType()];
        Type handlerType = type.MakeGenericType(typeArgs);
        ICommandHandler<ICommand> handler = (ICommandHandler<ICommand>)_provider.GetRequiredService(handlerType);

        await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<,>);
        Type typeResult = command.GetType().GetGenericArguments()[0];
        Type[] typeArgs = [command.GetType(), typeResult];
        Type handlerType = type.MakeGenericType(typeArgs);
        dynamic handler = _provider.GetRequiredService(handlerType);

        return await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}