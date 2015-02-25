using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;

namespace Draft
{
    internal static class FlurlDeleteExtensions
    {

        public static Task<HttpResponseMessage> DeleteAsync(this FlurlClient This, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.DeleteAsync(url, cancellationToken.Value) : http.DeleteAsync(url));
        }

        public static Task<HttpResponseMessage> DeleteAsync(this string This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).DeleteAsync(cancellationToken);
        }

        public static Task<HttpResponseMessage> DeleteAsync(this Url This, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).DeleteAsync(cancellationToken);
        }

    }
}
