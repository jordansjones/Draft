using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl;

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

    }
}
