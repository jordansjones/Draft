using System;
using System.Collections.Generic;

using Flurl.Http;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft
{
    internal static class FlurlResponseMessageExtensions
    {

        public static ResponseHeaders ParseResponseHeaders(this HttpResponseMessage This)
        {
            return new ResponseHeaders
            {
                ClusterId = This.TryGetHeader(Constants.Etcd.Header_ClusterId),
                CurrentIndex = This.TryGetHeaderAsLong(Constants.Etcd.Header_EtcdIndex),
                RaftIndex = This.TryGetHeaderAsLong(Constants.Etcd.Header_RaftIndex),
                RaftTerm = This.TryGetHeaderAsLong(Constants.Etcd.Header_RaftTerm)
            };
        }

        public static async Task<T> ReceiveEtcdResponse<T>(this Task<HttpResponseMessage> This)
            where T : IHaveResponseHeaders
        {
            var response = await This.ReceiveJson<T>();
            var httpMessage = await This;
            response.Headers = httpMessage.ParseResponseHeaders();
            return response;
        }

        public static string TryGetHeader(this HttpResponseMessage This, string key)
        {
            var headerValues = default(IEnumerable<string>);

            if (This.Headers.TryGetValues(key, out headerValues))
            {
                return headerValues.FirstOrDefault() ?? string.Empty;
            }
            return string.Empty;
        }

        public static long? TryGetHeaderAsLong(this HttpResponseMessage This, string key)
        {
            var headerValue = This.TryGetHeader(key);
            if (string.IsNullOrWhiteSpace(headerValue)) { return null; }

            long value;
            if (long.TryParse(headerValue, out value))
            {
                return value;
            }

            return null;
        }

    }
}
