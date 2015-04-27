using System;
using System.Linq;

namespace Draft.Endpoints
{
    internal sealed class RoutingStrategyConsistentKeyHashing : EndpointRoutingStrategy
    {

        public override Endpoint Select(string key, Endpoint[] endpoints)
        {

            return endpoints[GetOffset(key, endpoints.Length)];
        }

        internal static int GetOffset(string key, int totalItems)
        {
            var value = key.GetHashCode();
            return (value & int.MaxValue) % totalItems;
        }

    }
}
