using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class RoutingStrategyFirst : EndpointRoutingStrategy
    {

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            return endpoints.First(x => x.IsOnline);
        }

    }
}
