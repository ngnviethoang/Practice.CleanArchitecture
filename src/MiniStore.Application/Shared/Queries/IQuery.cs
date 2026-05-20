using MiniStore.Application.Shared.Common;

namespace MiniStore.Application.Shared.Queries;

public interface IQuery<TResult> : IRequest<TResult>;