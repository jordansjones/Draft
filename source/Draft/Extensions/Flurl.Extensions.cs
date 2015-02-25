using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Draft.Models;

using Flurl;
using Flurl.Http;

namespace Draft
{
    internal static class FlurlExtensions
    {

        public static Url Conditionally(this Url This, bool predicate, Func<Url, Url> action)
        {
            return predicate ? action(This) : This;
        }

        public static Url Conditionally<T>(this Url This, T item, Predicate<T> predicate, Func<Url, Url> action)
        {
            return predicate(item) ? action(This) : This;
        }

        public static Task<HttpResponseMessage> Conditionally(this Url This, bool predicate, object data, Func<Url, object, Task<HttpResponseMessage>> ifTrue, Func<Url, object, Task<HttpResponseMessage>> ifFalse)
        {
            return predicate ? ifTrue(This, data) : ifFalse(This, data);
        }


        public static ResponseHeaders ParseResponseHeaders(this HttpResponseMessage This)
        {
            return new ResponseHeaders
            {
                ClusterId = This.TryGetHeader(HeaderConstants.ClusterId),
                EtcdIndex = This.TryGetHeader(HeaderConstants.EtcdIndex),
                RaftIndex = This.TryGetHeader(HeaderConstants.RaftIndex),
                RaftTerm = This.TryGetHeader(HeaderConstants.RaftTerm)
            };
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
    }
}
