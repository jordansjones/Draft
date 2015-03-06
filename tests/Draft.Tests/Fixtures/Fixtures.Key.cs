using System;
using System.Linq;

using Draft.Constants;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class Key
        {

            public const int DefaultTtl = 300;

            public const string DefaultValue = "{DBAEDC45-175B-4310-8387-4F02F988253F}";

            public const string Path = "/foo/somekey";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

            public static string DefaultRequest(string value = DefaultValue)
            {
                return WithValue(value).AsRequestBody();
            }

            public static string ExistingRequest(string value = DefaultValue, bool existing = true)
            {
                return WithValue(value)
                    .ConditionallyAdd(existing, Constants.Etcd.Parameter_PrevExist, Constants.Etcd.Parameter_True)
                    .AsRequestBody();
            }

            public static string TtlRequest(string value = DefaultValue, int ttl = DefaultTtl)
            {
                return WithValue(value)
                    .Add(Constants.Etcd.Parameter_Ttl, ttl)
                    .AsRequestBody();
            }

            private static FormBodyBuilder<string, object> WithValue(string value)
            {
                return new FormBodyBuilder<string, object>()
                    .Add(Constants.Etcd.Parameter_Value, value);
            }

        }

    }
}
