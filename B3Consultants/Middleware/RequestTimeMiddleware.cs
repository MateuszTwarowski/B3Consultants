using System.Diagnostics;

namespace B3Consultants.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private readonly Stopwatch _stopwatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();
            _logger.LogInformation($"{context.Request.Method} at {context.Request.Path} request time: {_stopwatch.ElapsedMilliseconds} ms");
        }
    }
}