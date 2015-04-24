using System;
using System.Linq;

namespace Draft.Tests
{
    internal static partial class Fixtures
    {

        public static class Directory
        {

            public const int DefaultTtl = 300;

            public const string Path = "/new/directory";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

            public static FormBodyBuilder DefaultRequest
            {
                get
                {
                    return new FormBodyBuilder()
                        .Add(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True);
                }
            }

            public static FormBodyBuilder WithExistingRequest
            {
                get
                {
                    return DefaultRequest
                        .Add(Constants.Etcd.Parameter_PrevExist, Constants.Etcd.Parameter_True);
                }
            }


        }

    }
}
