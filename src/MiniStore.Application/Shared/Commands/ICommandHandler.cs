using MiniStore.Application.Shared.Common;

namespace MiniStore.Application.Shared.Commands;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>;