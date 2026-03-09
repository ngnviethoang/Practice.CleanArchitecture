using WeTicket.Application.Shared.Common;
using WeTicket.Domain.Events;

namespace WeTicket.Application.Shared.Dispatchers;

public interface IDispatcher
{
    Task<TResult> DispatchAsync<TResult>(IRequest<TResult> request, CancellationToken cancellationToken = default);

    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}