using System;
using System.Linq;

using Draft.Constants;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class Directory
        {

            public const int DefaultTtl = 300;

            public const string Path = "/new/directory";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

            public static FormBodyBuilder<string, object> DefaultRequest
            {
                get
                {
                    return new FormBodyBuilder<string, object>()
                        .Add(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True);
                }
            }

            public static FormBodyBuilder<string, object> WithExistingRequest
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
