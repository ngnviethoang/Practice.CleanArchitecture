using WeTicket.Application.Shared.Common;

namespace WeTicket.Application.Shared.Commands;

public interface ICommand<TResult> : IRequest<TResult>;