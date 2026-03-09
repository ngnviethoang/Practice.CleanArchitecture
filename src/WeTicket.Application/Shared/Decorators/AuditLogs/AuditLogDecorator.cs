using Microsoft.Extensions.Logging;
using WeTicket.Application.Shared.Common;

namespace WeTicket.Application.Shared.Decorators.AuditLogs;

public class AuditLogDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IRequestHandler<TRequest, TResult> _handler;
    private readonly ILogger<AuditLogDecorator<TRequest, TResult>> _logger;

    public AuditLogDecorator(
        IRequestHandler<TRequest, TResult> handler,
        ILogger<AuditLogDecorator<TRequest, TResult>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Handling request {@RequestName} {Request}", typeof(TRequest).Name, request);
        return await _handler.HandleAsync(request, cancellationToken);
    }
}