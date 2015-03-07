using System;
using System.Linq;

using Ploeh.AutoFixture;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public const string EtcdUrl = "http://localhost:4001";

        public const string RelativeEtcdUrl = "/foo/bar";

        private static readonly Fixture Fixture = new Fixture();

        public static object CreateErrorMessage(int? errorCode = null, string message = null, string cause = null, long? index = null)
        {
            var dict = new ListDictionary();

            if (errorCode != null)
            {
                dict.Add("errorCode", errorCode.Value);
            }

            if (message != null)
            {
                dict.Add("message", message);
            }

            if (cause != null)
            {
                dict.Add("cause", cause);
            }

            dict.Add("index", index ?? Fixture.Create<long>());

            return dict;
        }

    }
}
