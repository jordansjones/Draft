using System;
using System.Linq;
using System.Threading;

namespace Draft.Endpoints
{
    internal sealed class RoutingStrategyRoundRobin : EndpointRoutingStrategy
    {

        private int _next = -1;

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            return endpoints[(Interlocked.Increment(ref _next) & int.MaxValue) % endpoints.Length];
        }

    }
}
