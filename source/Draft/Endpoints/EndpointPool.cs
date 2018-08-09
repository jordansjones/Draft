using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using Flurl;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Pool of Etcd Endpoints
    /// </summary>
    [Serializable, DataContract]
    public sealed partial class EndpointPool
    {

        internal EndpointPool(IEnumerable<Endpoint> endpoints, EndpointRoutingStrategy routingStrategy)
        {
            AllEndpoints = endpoints.ToList();
            RoutingStrategy = routingStrategy;
        }

        [DataMember(Order = 1)]
        internal List<Endpoint> AllEndpoints { get; private set; }

        [IgnoreDataMember]
        internal Endpoint[] OnlineEndpoints
        {
            get { return AllEndpoints.Where(x => x.IsOnline).ToArray(); }
        }

        [DataMember(Order = 2)]
        internal EndpointRoutingStrategy RoutingStrategy { get; private set; }

        internal Url GetEndpointUrl(params string[] pathParts)
        {
            var pathSegment = new NormalizedPathSegment(pathParts);
            return pathSegment.ToUrl(RoutingStrategy.Select(pathSegment.Value, OnlineEndpoints).Uri);
        }

        [IgnoreDataMember]
        internal TimeSpan? HttpGetTimeout { get; set; } = null;

    }
}
