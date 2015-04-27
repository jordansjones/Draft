using System;
using System.Linq;

namespace Draft.Endpoints
{
    internal sealed class RoutingStrategyFirst : EndpointRoutingStrategy
    {

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            return endpoints.First(x => x.IsOnline);
        }

    }
}
