using System;
using System.Linq;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class CompareAndSwap
        {

            public const int DefaultTtl = 300;

            public const long ExpectedIndex = 32;

            public const string ExpectedValue = "{B6D19813-0A6B-4D4A-9236-C56F6AB89DE6}";

            public const string NewValue = "{7564D465-FFA8-4431-B248-03372193E4D4}";

            public const string Path = "/foo/cas";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

            public static string DefaultRequest(string value = NewValue)
            {
                return WithValue(value)
                    .AsRequestBody();
            }

            public static string TtlRequest(string value = NewValue, int ttl = DefaultTtl)
            {
                return WithValue(value)
                    .Add(EtcdConstants.Parameter_Ttl, ttl)
                    .AsRequestBody();
            }

            private static FormBodyBuilder<string, object> WithValue(string value)
            {
                return new FormBodyBuilder<string, object>()
                    .Add(EtcdConstants.Parameter_Value, value);
            }
        }

    }
}
