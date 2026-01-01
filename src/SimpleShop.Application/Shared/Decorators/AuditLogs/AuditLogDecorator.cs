using Microsoft.Extensions.Logging;
using SimpleShop.Application.Shared.Common;

namespace SimpleShop.Application.Shared.Decorators.AuditLogs;

public class AuditLogCommandDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IRequestHandler<TRequest, TResult> _handler;
    private readonly ILogger<AuditLogCommandDecorator<TRequest, TResult>> _logger;

    public AuditLogCommandDecorator(
        IRequestHandler<TRequest, TResult> handler,
        ILogger<AuditLogCommandDecorator<TRequest, TResult>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResult> HandleAsync(
        TRequest request,
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Handling request {CommandName} {@Command}", typeof(TRequest).Name, request);
        return await _handler.HandleAsync(request, cancellationToken);
    }
}