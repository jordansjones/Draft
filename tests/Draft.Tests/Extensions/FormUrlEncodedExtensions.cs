using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Flurl;
using Flurl.Http.Content;
using Flurl.Util;

namespace Draft.Tests
{
    internal static class FormUrlEncodedExtensions
    {

        public static string AsRequestBody(this FormBodyBuilder This)
        {
            return This.Build().AsRequestBody();
        }

        public static string AsRequestBody(this IEnumerable<KeyValuePair<object, object>> This)
        {
            return new CapturedUrlEncodedContent(AsUrlEncodedContent(This)).Content;
        }

        private static string AsUrlEncodedContent(IEnumerable<KeyValuePair<object, object>> collection)
        {
            var kvItems = (collection ?? Enumerable.Empty<KeyValuePair<object, object>>())
                .Where(x => x.Value != null)
                .Select(kv => string.Join("=", Url.Encode(kv.Key.ToInvariantString(), true), Url.Encode(kv.Value.ToString(), true)));

            return string.Join("&", kvItems);
        }

    }
}
