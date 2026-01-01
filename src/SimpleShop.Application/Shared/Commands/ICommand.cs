using SimpleShop.Application.Shared.Common;

namespace SimpleShop.Application.Shared.Commands;

public interface ICommand<TResult> : IRequest<TResult>;