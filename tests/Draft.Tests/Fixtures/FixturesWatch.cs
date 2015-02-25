﻿using System;
using System.Linq;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class Watch
        {

            public const string Path = "/foo/bar";

            public static readonly object DefaultResponse = new
            {
                Message = "Foo"
            };

        }

    }
}
