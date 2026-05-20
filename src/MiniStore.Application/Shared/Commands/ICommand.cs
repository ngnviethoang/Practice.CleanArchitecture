using MiniStore.Application.Shared.Common;

namespace MiniStore.Application.Shared.Commands;

public interface ICommand<TResult> : IRequest<TResult>;