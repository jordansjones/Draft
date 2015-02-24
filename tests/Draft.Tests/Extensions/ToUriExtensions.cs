using System;
using System.Linq;

using Flurl;

namespace Draft.Tests
{
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
