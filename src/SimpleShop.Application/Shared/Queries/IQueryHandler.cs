using SimpleShop.Application.Shared.Common;

namespace SimpleShop.Application.Shared.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(IRequest<TResult> query, CancellationToken cancellationToken = default);
}