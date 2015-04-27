using System;
using System.Collections.Generic;
using System.Linq;

using Flurl;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Pool of Etcd Endpoints
    /// </summary>
    public sealed partial class EndpointPool
    {

        internal EndpointPool(IEnumerable<Endpoint> endpoints, EndpointRoutingStrategy routingStrategy)
        {
            AllEndpoints = endpoints.ToList();
            RoutingStrategy = routingStrategy;
        }

        internal List<Endpoint> AllEndpoints { get; private set; }

        internal Endpoint[] OnlineEndpoints
        {
            get { return AllEndpoints.Where(x => x.IsOnline).ToArray(); }
        }

        internal EndpointRoutingStrategy RoutingStrategy { get; private set; }

        internal Url GetEndpointUrl(params string[] pathParts)
        {
            pathParts = pathParts ?? new string[0];

            var keyPath = string.Join("/", pathParts.Select(x => x.TrimStart('/').TrimEnd('/')));

            return RoutingStrategy.Select(keyPath, OnlineEndpoints).Uri.ToUrl()
                                  .AppendPathSegment(keyPath);
        }

    }
}
