using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class RoutingStrategyRoundRobin : EndpointRoutingStrategy
    {

        [DataMember(Order = 1)]
        private int _next = -1;

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {
            return endpoints[(Interlocked.Increment(ref _next) & int.MaxValue) % endpoints.Length];
        }

    }
}
