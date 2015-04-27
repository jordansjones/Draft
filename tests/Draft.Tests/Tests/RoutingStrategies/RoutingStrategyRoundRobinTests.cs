using System;
using System.Collections.Generic;
using System.Linq;

using Draft.Endpoints;

using FluentAssertions;

using Xunit;

namespace Draft.Tests.RoutingStrategies
{
    public class RoutingStrategyRoundRobinTests : BaseRoutingStrategyTests
    {

        private Endpoint[] Endpoints
        {
            get { return new[] {Endpoint1, Endpoint2, Endpoint3, Endpoint4, Endpoint5}; }
        }

        protected override EndpointRoutingStrategy RoutingStrategy
        {
            get { return new RoutingStrategyRoundRobin(); }
        }

        [Fact]
        public void ShouldAlwaysSelectTheSameWithSingleEndpoint()
        {
            var sut = CreateSut(RoutingStrategy, Endpoint1);

            for (var i = 0; i < 100; i++)
            {
                var result = sut.GetEndpointUrl();
                result.Should().NotBeNull();
                result.ToString()
                      .Should()
                      .BeSameAs(Endpoint1.Uri.ToString());
            }
        }

        [Fact]
        public void ShouldInitiallySelectTheFirstEndpoint()
        {
            var sut = CreateSut(RoutingStrategy, Endpoints);
            var result = sut.GetEndpointUrl();

            result.Should().NotBeNull();

            result.ToString()
                  .Should()
                  .BeSameAs(Endpoint1.Uri.ToString());
        }

        [Fact]
        public void ShouldSelectAllEndpointsSequentially()
        {
            var sut = CreateSut(RoutingStrategy, Endpoints);

            foreach (var expected in Endpoints)
            {
                var result = sut.GetEndpointUrl();
                result.Should().NotBeNull();
                result.ToString()
                      .Should()
                      .BeSameAs(expected.Uri.ToString());
            }
        }

        [Fact]
        public void ShouldSelectAllEndpointsSequentiallyContinually()
        {
            var sut = CreateSut(RoutingStrategy, Endpoints);
            var expectedResults = new List<Endpoint>();
            expectedResults.AddRange(Endpoints);
            expectedResults.AddRange(Endpoints);
            expectedResults.AddRange(Endpoints);
            expectedResults.AddRange(Endpoints);
            expectedResults.AddRange(Endpoints);

            foreach (var expected in expectedResults)
            {
                var result = sut.GetEndpointUrl();
                result.Should().NotBeNull();
                result.ToString()
                      .Should()
                      .BeSameAs(expected.Uri.ToString());
            }
        }

    }
}
