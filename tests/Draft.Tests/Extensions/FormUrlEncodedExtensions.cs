using System;
using System.Collections;
using System.Linq;

using Flurl.Http.Content;

namespace Draft.Tests
{
    internal static class FormUrlEncodedExtensions
    {

        public static string AsRequestBody(this FormBodyBuilder This)
        {
            return This.Build().AsRequestBody();
        }

        public static string AsRequestBody(this IDictionary This)
        {
            return new CapturedUrlEncodedContent(This).Content;
        }

    }
}
