using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;

namespace BC.ACCOUNTING.REPORT.ImageCache
{
    public class ImageCache : IImageCache
    {
        public async Task<Dictionary<string, byte[]>> PrefetchAsync(IHttpClientFactory factory, List<string> urls,
            CancellationToken ct)
        {
            var client = factory.CreateClient("images");
            var unique = urls.Where(u => !string.IsNullOrWhiteSpace(u)).Distinct().ToArray();

            var tasks = unique.Select(async u =>
            {
                using var r = await client.GetAsync(u, HttpCompletionOption.ResponseHeadersRead, ct);
                var success = r.IsSuccessStatusCode;
                var bytes = success ? await r.Content.ReadAsByteArrayAsync(ct) : null;
                return (u, ok: success, bytes);
            });

            var results = await Task.WhenAll(tasks);
            return results.Where(x => x.ok && x.bytes != null)
                .ToDictionary(x => x.u, x => x.bytes!);
        }
    }
}
