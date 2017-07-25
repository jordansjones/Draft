using System;
using System.Linq;

using Draft.Endpoints;

using FluentAssertions;

using Xunit;

namespace Draft.Tests.RoutingStrategies
{
    public class RoutingStrategyFirstTests : BaseRoutingStrategyTests
    {

        private Endpoint[] Endpoints
        {
            get { return new[] {Endpoint1, Endpoint2, Endpoint3, Endpoint4, Endpoint5}; }
        }

        protected override EndpointRoutingStrategy RoutingStrategy
        {
            get { return new RoutingStrategyFirst(); }
        }

        [Fact]
        public void ShouldInitiallySelectTheFirstEndpoint()
        {
            var sut = CreateSut(RoutingStrategy, Endpoints);

            var result = sut.GetEndpointUrl();
            result.Should().NotBeNull();
            result.ToString()
                  .Should()
                  .Be(Endpoint1.Uri.ToString());
        }

    }
}
