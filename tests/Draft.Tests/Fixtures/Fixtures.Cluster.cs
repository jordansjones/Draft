using System;
using System.Linq;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class Cluster
        {

            public static object CreateResponse(params Uri[] peerUris)
            {
                return new
                {
                    id = Guid.NewGuid().ToString(),
                    peerURLs = peerUris.Select(x => x.ToString()).ToArray()
                };
            }

        }

    }
}
