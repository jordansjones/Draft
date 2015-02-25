using System;
using System.Collections;
using System.Linq;

using Flurl.Http.Content;

namespace Draft.Tests
{
    public static class FormUrlEncodedExtensions
    {

        public static string AsRequestBody(this FormBodyBuilder<string, object> This)
        {
            return This.Build().AsRequestBody();
        }

        public static string AsRequestBody(this IDictionary This)
        {
            return new CapturedFormUrlEncodedContent(This).Content;
        }

    }
}
