namespace Param_.Net_Practicum.Middlewares
{
    /// <summary>
    /// It prints which action the incoming request is working in.
    /// </summary>
    public class LogginMiddware : IMiddleware
    {
        private readonly ILogger<LogginMiddware> _logger;

        public LogginMiddware(ILogger<LogginMiddware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"{context.Request.Path} was runnig");
            await next(context);
        }
    }
}
