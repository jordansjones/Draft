using System;
using System.Linq;

using AutoFixture;

namespace Draft.Tests
{
    internal static partial class Fixtures
    {

        public const string EtcdUrl = "http://localhost:4001";

        public const string RelativeEtcdUrl = "/foo/bar";

        private static readonly Fixture Fixture = new Fixture();

        public static object CreateErrorMessage(int? errorCode = null, string message = null, string cause = null, long? index = null)
        {
            return new FormBodyBuilder()
                // ReSharper disable once PossibleInvalidOperationException
                .Add(errorCode.HasValue, "errorCode", () => errorCode.Value)
                .Add(message != null, "message", () => message)
                .Add(cause != null, "cause", () => cause)
                .Add("index", index ?? Fixture.Create<long>())
                .Build();
        }

    }
}
