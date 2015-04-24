using System;
using System.Linq;

namespace Draft.Tests
{
    internal static partial class Fixtures
    {

        public static class CompareAndDelete
        {

            public const long ExpectedIndex = 57;

            public const string ExpectedValue = "{DEFEA7C5-F142-4FED-9D69-25095F5F669A}";

            public const string Path = "/foo/compareanddelete";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

        }

    }
}
