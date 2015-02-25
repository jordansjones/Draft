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
    internal static class FlurlPutExtensions
    {

        public static Task<HttpResponseMessage> PutJsonAsync(this FlurlClient This, object data, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            var content = new CapturedJsonContent(data);
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.PutAsync(url, content, cancellationToken.Value) : http.PutAsync(url, content));
        }

        public static Task<HttpResponseMessage> PutJsonAsync(this string This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PutJsonAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PutJsonAsync(this Url This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PutJsonAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PutUrlEncodedAsync(this FlurlClient This, object data, CancellationToken? cancellationToken = null)
        {
            var url = This.Url;
            var content = new CapturedFormUrlEncodedContent(data);
            return This.DoCallAsync(http => cancellationToken.HasValue ? http.PutAsync(url, content, cancellationToken.Value) : http.PutAsync(url, content));
        }

        public static Task<HttpResponseMessage> PutUrlEncodedAsync(this string This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PutUrlEncodedAsync(data, cancellationToken);
        }

        public static Task<HttpResponseMessage> PutUrlEncodedAsync(this Url This, object data, CancellationToken? cancellationToken = null)
        {
            return new FlurlClient(This, true).PutUrlEncodedAsync(data, cancellationToken);
        }

    }
}
