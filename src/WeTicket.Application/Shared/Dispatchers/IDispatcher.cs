using WeTicket.Application.Shared.Commands;
using WeTicket.Application.Shared.Queries;
using WeTicket.Domain.Events;

namespace WeTicket.Application.Shared.Dispatchers;

public interface IDispatcher
{
    Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);

    Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);

    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}