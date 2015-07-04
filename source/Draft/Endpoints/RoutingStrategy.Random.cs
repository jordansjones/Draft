using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class RoutingStrategyRandom : EndpointRoutingStrategy
    {

        [NonSerialized, IgnoreDataMember]
        private IRandom _random;

        public RoutingStrategyRandom() : this(StaticRandom.Instance) {}

        public RoutingStrategyRandom(IRandom random)
        {
            _random = random ?? StaticRandom.Instance;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext ignored)
        {
            _random = _random ?? StaticRandom.Instance;
        }

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            var ecount = endpoints.Length;
            return endpoints[_random.Next(ecount - 1) % ecount];
        }

    }
}
