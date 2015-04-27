using System;
using System.Linq;

using Draft.Endpoints;

namespace Draft.Tests.RoutingStrategies
{
    public abstract class BaseRoutingStrategyTests
    {

        protected static readonly Endpoint Endpoint1 = CreateEndpoint("http://localhost:1/");

        protected static readonly Endpoint Endpoint2 = CreateEndpoint("http://localhost:2/");

        protected static readonly Endpoint Endpoint3 = CreateEndpoint("http://localhost:3/");

        protected static readonly Endpoint Endpoint4 = CreateEndpoint("http://localhost:4/");

        protected static readonly Endpoint Endpoint5 = CreateEndpoint("http://localhost:5/");

        protected abstract EndpointRoutingStrategy RoutingStrategy { get; }

        protected static Endpoint CreateEndpoint(string url, EndpointAvailability ea = EndpointAvailability.Online)
        {
            return new Endpoint(new Uri(url), ea);
        }

        protected EndpointPool CreateSut(EndpointRoutingStrategy strategy = null, params Endpoint[] endpoints)
        {
            return new EndpointPool(
                endpoints == null || !endpoints.Any()
                    ? new[] {Endpoint1, Endpoint2, Endpoint3, Endpoint4, Endpoint5}
                    : endpoints,
                strategy ?? RoutingStrategy
                );
        }

    }
}
