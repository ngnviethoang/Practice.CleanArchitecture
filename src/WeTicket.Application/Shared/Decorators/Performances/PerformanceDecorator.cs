using System.Diagnostics;
using Microsoft.Extensions.Logging;
using WeTicket.Application.Shared.Common;

namespace WeTicket.Application.Shared.Decorators.Performances;

public class PerformanceDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private const int _slowRequestThresholdMs = 5000;
    private readonly IRequestHandler<TRequest, TResult> _handler;
    private readonly ILogger<PerformanceDecorator<TRequest, TResult>> _logger;

    public PerformanceDecorator(
        IRequestHandler<TRequest, TResult> handler,
        ILogger<PerformanceDecorator<TRequest, TResult>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        TResult result = await _handler.HandleAsync(request, cancellationToken);

        stopwatch.Stop();

        long elapsedMs = stopwatch.ElapsedMilliseconds;
        string requestName = typeof(TRequest).Name;

        if (elapsedMs > _slowRequestThresholdMs)
        {
            _logger.LogWarning(
                "Long running request {RequestName} took {ElapsedMilliseconds} ms {@Request}",
                requestName,
                elapsedMs,
                request
            );
        }
        else
        {
            _logger.LogInformation(
                "Request {RequestName} completed in {ElapsedMilliseconds} ms",
                requestName,
                elapsedMs
            );
        }

        return result;
    }
}