using MiniStore.Application.Shared.Common;

namespace MiniStore.Application.Shared.Queries;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>;