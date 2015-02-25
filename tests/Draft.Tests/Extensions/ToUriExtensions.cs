using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Flurl;

namespace Draft.Tests
{
    [ExcludeFromCodeCoverage]
    public static class ToUriExtensions
    {

        public static Uri ToUri(this string This)
        {
            return new Uri(This);
        }

        public static Uri ToUri(this Url This)
        {
            return This.ToString().ToUri();
        }

    }
}
