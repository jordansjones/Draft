using System;
using System.Linq;

using Ploeh.AutoFixture;

namespace Draft.Tests
{
    internal static partial class Fixtures
    {

        public static class Key
        {

            public const long DefaultTtl = 300;

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
                    .Add(Constants.Etcd.Parameter_PrevExist, existing ? Constants.Etcd.Parameter_True : Constants.Etcd.Parameter_False)
                    .AsRequestBody();
            }

            public static string TtlRequest(string value = DefaultValue, long ttl = DefaultTtl)
            {
                return WithValue(value)
                    .Add(Constants.Etcd.Parameter_Ttl, ttl)
                    .AsRequestBody();
            }

            public static string TtlTimeSpanRequest(string value = DefaultValue, TimeSpan? ttl = null)
            {
                var ttlValue = ttl ?? TimeSpan.FromSeconds(DefaultTtl);
                return TtlRequest(value, Convert.ToInt64(ttlValue.TotalSeconds));
            }

            public static object UpsertResponse(string keyPath, string value, string previousValue = null)
            {
                var hasPreviousValue = !string.IsNullOrWhiteSpace(previousValue);
                var modifiedIndex = Fixture.Create<long>();
                var createdIndex = hasPreviousValue ? modifiedIndex - 10 : modifiedIndex;

                var nodeValues = new FormBodyBuilder()
                    .Add("createdIndex", createdIndex)
                    .Add("key", keyPath)
                    .Add("modifiedIndex", modifiedIndex)
                    .Add("value", value)
                    .Build();

                var response = new FormBodyBuilder()
                    .Add("action", "set")
                    .Add("node", nodeValues)
                    .Build();

                if (hasPreviousValue)
                {
                    response["prevNode"] = new FormBodyBuilder()
                        .Add("createdIndex", createdIndex)
                        .Add("key", keyPath)
                        .Add("modifiedIndex", createdIndex)
                        .Add("value", previousValue)
                        .Build();
                }

                return response;
            }

            private static FormBodyBuilder WithValue(string value)
            {
                return new FormBodyBuilder()
                    .Add(Constants.Etcd.Parameter_Value, value);
            }

        }

    }
}
