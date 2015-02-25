using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Draft
{
    internal static class FlurlPostExtensions
    {

        public static Task<HttpResponseMessage> PostJsonAsync(this FlurlClient This, object data, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            var content = new CapturedJsonContent(data);
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.PostAsync(url, content, cancellationToken.Value) : http.PostAsync(url, content));
        }

        public static Task<HttpResponseMessage> PostJsonAsync(this string This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PostJsonAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PostJsonAsync(this Url This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PostJsonAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PostUrlEncodedAsync(this FlurlClient This, object data, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            var content = new CapturedFormUrlEncodedContent(data);
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.PostAsync(url, content, cancellationToken.Value) : http.PostAsync(url, content));
        }

        public static Task<HttpResponseMessage> PostUrlEncodedAsync(this string This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PostUrlEncodedAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PostUrlEncodedAsync(this Url This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PostUrlEncodedAsync(data, cancellationToken);
        }

    }
}
