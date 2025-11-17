using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace BC.ACCOUNTING.REPORT
{
    public sealed class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _log;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (Exception ex)
            {
                var corrId = ctx.Items["X-Correlation-Id"] as string ?? ctx.TraceIdentifier;
                var user = ctx.User?.Identity?.Name ?? "(anon)";
                _log.LogError(ex, "Unhandled exception. CorrId={CorrelationId} User={User} Path={Path}",
                    corrId, user, ctx.Request.Path);
                throw; 
            }
        }
    }
}
