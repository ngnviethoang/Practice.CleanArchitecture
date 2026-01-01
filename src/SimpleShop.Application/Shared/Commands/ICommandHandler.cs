using SimpleShop.Application.Shared.Common;

namespace SimpleShop.Application.Shared.Commands;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(IRequest<TResult> command, CancellationToken cancellationToken = default);
}