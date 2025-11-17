using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace BC.ACCOUNTING.REPORT.ImageCache
{
    public interface IImageCache
    {
        Task<Dictionary<string, byte[]>> PrefetchAsync(IHttpClientFactory factory, List<string> urls,
            CancellationToken ct);
    }
}
