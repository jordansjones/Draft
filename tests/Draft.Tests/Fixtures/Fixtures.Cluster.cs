using System;
using System.Linq;

namespace Draft.Tests
{
    internal static partial class Fixtures
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

            public static object ClusterHealthResponse(bool isHealthy = true)
            {
                return new
                {
                    health = isHealthy
                };
            }

            public static object ClusterMemberResponse(Uri[] clientUris = null, Uri[] peerUris = null)
            {
                return new
                {
                    id = Guid.NewGuid().ToString(),
                    name = Guid.NewGuid().ToString(),
                    clientURLs = (clientUris ?? new Uri[0]).Select(x => x.ToString()).ToArray(),
                    peerURLs = (peerUris ?? new Uri[0]).Select(x => x.ToString()).ToArray()
                };
            }

            public static object ClusterMembersResponse(params object[] members)
            {
                return new
                {
                    members = members
                };
            }

        }

    }
}
