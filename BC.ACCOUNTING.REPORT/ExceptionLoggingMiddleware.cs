using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace BC.ACCOUNTING.REPORT
{
    public sealed class ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> log)
    {
        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await next(ctx);
            }
            catch (Exception ex)
            {
                var corrId = ctx.Items["X-Correlation-Id"] as string ?? ctx.TraceIdentifier;
                var user = ctx.User?.Identity?.Name ?? "(anon)";
                log.LogError(ex, "Unhandled exception. CorrId={CorrelationId} User={User} Path={Path}",
                    corrId, user, ctx.Request.Path);
                throw; 
            }
        }
    }
}
