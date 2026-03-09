using WeTicket.Application.Shared.Common;

namespace WeTicket.Application.Shared.Commands;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>;