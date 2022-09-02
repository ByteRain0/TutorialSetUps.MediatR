using System.Diagnostics;
using MediatR;

namespace VoyagerAPI.Infrastructure;

public class RequestPerformanceMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer
        = new Stopwatch();

    private readonly ILogger<TRequest> _logger;

    public RequestPerformanceMiddleware(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        if (_timer.ElapsedMilliseconds <= 5000) return response;
        var name = typeof(TRequest).Name;

        _logger.LogWarning("Long Running Request: '{Name}' ({ElapsedTime} milliseconds) '{Request}'", name, _timer.ElapsedMilliseconds, request);

        return response;
    }
}
