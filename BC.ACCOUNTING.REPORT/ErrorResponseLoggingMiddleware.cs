using Microsoft.Extensions.Logging;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BC.ACCOUNTING.REPORT
{
    public sealed class ErrorResponseLoggingMiddleware(
        RequestDelegate next,
        ILogger<ErrorResponseLoggingMiddleware> log,
        IConfiguration cfg)
    {
        private readonly bool _logReqBody = cfg.GetValue("Logging:LogRequestBodyOnError", true);
        private readonly int _maxBody = cfg.GetValue("Logging:MaxLoggedBodyBytes", 10485760);
        private readonly string[] _maskFields = cfg.GetSection("Logging:MaskFields").Get<string[]>() ?? [];
        private readonly bool _pretty = cfg.GetValue("Logging:PrettyPrintJson", true);

        public async Task Invoke(HttpContext ctx)
        {
            string? requestBody = null;
            if (_logReqBody && LooksLikeJson(ctx.Request.ContentType))
            {
                ctx.Request.EnableBuffering();
                using var reader = new StreamReader(ctx.Request.Body, leaveOpen: true);
                requestBody = await reader.ReadToEndAsync();
                ctx.Request.Body.Position = 0;

                requestBody = TryMaskJson(requestBody, _maskFields);
                requestBody = MaybePretty(requestBody, _pretty);
                requestBody = Truncate(requestBody, _maxBody);
            }

            var originalBody = ctx.Response.Body;
            await using var mem = new MemoryStream();
            ctx.Response.Body = mem;

            try
            {
                await next(ctx);
            }
            finally
            {
                mem.Position = 0;
                var responseText = await new StreamReader(mem).ReadToEndAsync();
                mem.Position = 0;

                await mem.CopyToAsync(originalBody);
                ctx.Response.Body = originalBody;

                    var corrId = ctx.Items["X-Correlation-Id"] as string ?? ctx.TraceIdentifier;
                    var user = ctx.User?.Identity?.Name ?? "(anon)";

                    var isJson = LooksLikeJson(ctx.Response.ContentType) || TryGuessJson(responseText);

                    var resOut = isJson
                        ? Truncate(MaybePretty(responseText, _pretty), _maxBody)
                        : "(non-JSON response)";

                    log.LogWarning(
                        "HTTP {Status} {Method} {Path} CorrId={CorrelationId} User={User}\nReqBody:\n{ReqBody}\nResBody:\n{ResBody}",
                        ctx.Response.StatusCode, ctx.Request.Method, ctx.Request.Path, corrId, user,
                        requestBody ?? "(not logged)", resOut);
                
            }
        }

        private static bool LooksLikeJson(string? contentType)
            => !string.IsNullOrWhiteSpace(contentType) &&
               contentType.IndexOf("json", StringComparison.OrdinalIgnoreCase) >= 0;

        private static bool TryGuessJson(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.TrimStart();
            return t.StartsWith("{") || t.StartsWith("[");
        }

        private static string Truncate(string? s, int max)
            => string.IsNullOrEmpty(s) ? s ?? "" : (s.Length <= max ? s : s[..max] + "...(truncated)");

        private static string MaybePretty(string? json, bool pretty)
        {
            if (!pretty || string.IsNullOrWhiteSpace(json)) return json ?? "";
            try
            {
                using var doc = JsonDocument.Parse(json);
                var opts = new JsonSerializerOptions { WriteIndented = true };
                return JsonSerializer.Serialize(ToAnon(doc.RootElement), opts);
            }
            catch { return json!; }
        }

        private static object? ToAnon(JsonElement el) => el.ValueKind switch
        {
            JsonValueKind.Object => el.EnumerateObject().ToDictionary(p => p.Name, p => ToAnon(p.Value)),
            JsonValueKind.Array => el.EnumerateArray().Select(ToAnon).ToArray(),
            _ => el.Deserialize<object>()
        };

        private static string TryMaskJson(string? json, IEnumerable<string> fields)
        {
            if (string.IsNullOrWhiteSpace(json)) return json ?? "";
            try
            {
                using var doc = JsonDocument.Parse(json);
                var masked = MaskElement(doc.RootElement, fields.Select(f => f.ToLowerInvariant()).ToHashSet());
                return JsonSerializer.Serialize(masked);
            }
            catch { return json!; }
        }

        private static object? MaskElement(JsonElement el, HashSet<string> mask) => el.ValueKind switch
        {
            JsonValueKind.Object => el.EnumerateObject().ToDictionary(
                p => p.Name,
                p => mask.Contains(p.Name.ToLowerInvariant()) ? (object?)"***" : MaskElement(p.Value, mask)),
            JsonValueKind.Array => el.EnumerateArray().Select(x => MaskElement(x, mask)).ToArray(),
            _ => el.Deserialize<object>()
        };
    }
}
