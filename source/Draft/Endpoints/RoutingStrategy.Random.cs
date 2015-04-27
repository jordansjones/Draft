using System;
using System.Linq;

namespace Draft.Endpoints
{
    internal sealed class RoutingStrategyRandom : EndpointRoutingStrategy
    {

        private readonly IRandom _random;

        public RoutingStrategyRandom() : this(StaticRandom.Instance) {}

        public RoutingStrategyRandom(IRandom random)
        {
            _random = random ?? StaticRandom.Instance;
        }

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            var ecount = endpoints.Length;
            return endpoints[_random.Next(ecount - 1) % ecount];
        }

    }
}
