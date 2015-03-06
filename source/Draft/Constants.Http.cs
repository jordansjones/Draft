using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Draft
{
    internal static partial class Constants
    {

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static class Http
        {

            public const string ContentType_ApplicationJson = "application/json";

        }

        #region Http Constant Extension Methods

        public static bool IsJson(this MediaTypeHeaderValue This)
        {
            if (This == null || string.IsNullOrWhiteSpace(This.MediaType)) { return false; }

            return This.MediaType.Equals(Http.ContentType_ApplicationJson, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsJsonContentType(this HttpRequestMessage This)
        {
            return This != null
                   && This.Content != null
                   && This.Content.Headers != null
                   && This.Content.Headers.ContentType != null
                   && This.Content.Headers.ContentType.IsJson();
        }

        public static bool IsJsonContentType(this HttpResponseMessage This)
        {
            return This != null
                   && This.Content != null
                   && This.Content.Headers != null
                   && This.Content.Headers.ContentType != null
                   && This.Content.Headers.ContentType.IsJson();
        }

        #endregion
    }
}
