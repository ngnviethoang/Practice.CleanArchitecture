using WeTicket.Application.Shared.Common;

namespace WeTicket.Application.Shared.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(IRequest<TResult> query, CancellationToken cancellationToken = default);
}