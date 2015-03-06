using System;
using System.Linq;

using Draft.Tests.Assertions;

using Flurl.Http.Testing;

// ReSharper disable once CheckNamespace
namespace Draft.Tests
{
    public static partial class HttpTestExtensions
    {

        public static HttpTestFluentAssertions Should(this HttpTest This)
        {
            return new HttpTestFluentAssertions(This.CallLog);
        }

    }
}
