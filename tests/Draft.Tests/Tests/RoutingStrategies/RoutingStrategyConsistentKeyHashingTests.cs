using System;

using FluentAssertions;

using System.Linq;

using Draft.Endpoints;

using Xunit;

namespace Draft.Tests.RoutingStrategies
{
    public class RoutingStrategyConsistentKeyHashingTests : BaseRoutingStrategyTests
    {

        private Endpoint[] Endpoints
        {
            get { return new[] {Endpoint1, Endpoint2, Endpoint3, Endpoint4, Endpoint5}; }
        }

        protected override EndpointRoutingStrategy RoutingStrategy
        {
            get { return new RoutingStrategyConsistentKeyHashing(); }
        }

        [Fact]
        public void ShouldAlwaysSelectTheSameEndpointWithHardcodedKey()
        {
            var sut = CreateSut(RoutingStrategy, Endpoints);

            for (var i = 0; i < 100; i++)
            {
                var result = sut.GetEndpointUrl("35b0c8db-f305-4e5c-95f7-cf1d77cfcc18");

                result.Should().NotBeNull();
                result.ToString()
                      .Should()
                      .StartWith(Endpoint1.Uri.ToString());
            }
        }

        [Fact]
        public void ShouldAlwaysSelectTheSameEndpointWithGeneratedKey()
        {
            var bytes = new byte[StaticRandom.Instance.Next(100, 1000)];
            StaticRandom.Instance.NextBytes(bytes);

            var key1 = Guid.NewGuid().ToString();
            var key2 = StaticRandom.Instance.Next().ToString();
            var key3 = Convert.ToBase64String(bytes);
            var key4 = StaticRandom.Instance.NextDouble().ToString("G");

            var key1Offset = RoutingStrategyConsistentKeyHashing.GetOffset(key1, Endpoints.Length);
            var key2Offset = RoutingStrategyConsistentKeyHashing.GetOffset(key2, Endpoints.Length);
            var key3Offset = RoutingStrategyConsistentKeyHashing.GetOffset(key3, Endpoints.Length);
            var key4Offset = RoutingStrategyConsistentKeyHashing.GetOffset(key4, Endpoints.Length);

            var sut = CreateSut(RoutingStrategy, Endpoints);

            for (var i = 0; i < 500; i++)
            {
                var result1 = sut.GetEndpointUrl(key1);
                var result2 = sut.GetEndpointUrl(key2);
                var result3 = sut.GetEndpointUrl(key3);
                var result4 = sut.GetEndpointUrl(key4);

                result1.Should().NotBeNull();
                result2.Should().NotBeNull();
                result3.Should().NotBeNull();
                result4.Should().NotBeNull();

                result1.ToString()
                       .Should()
                       .StartWith(Endpoints[key1Offset].Uri.ToString());

                result2.ToString()
                       .Should()
                       .StartWith(Endpoints[key2Offset].Uri.ToString());

                result3.ToString()
                       .Should()
                       .StartWith(Endpoints[key3Offset].Uri.ToString());

                result4.ToString()
                       .Should()
                       .StartWith(Endpoints[key4Offset].Uri.ToString());
            }
        }

    }
}
