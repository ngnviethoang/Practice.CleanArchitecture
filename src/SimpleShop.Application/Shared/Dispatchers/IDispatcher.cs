using SimpleShop.Application.Shared.Commands;
using SimpleShop.Application.Shared.Queries;
using SimpleShop.Domain.Events;

namespace SimpleShop.Application.Shared.Dispatchers;

public interface IDispatcher
{
    Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default);

    Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);

    Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);

    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}