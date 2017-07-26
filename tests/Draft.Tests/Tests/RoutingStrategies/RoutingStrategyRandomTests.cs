using System;

using Draft.Endpoints;

using FluentAssertions;

using Xunit;

namespace Draft.Tests.RoutingStrategies
{
    public class RoutingStrategyRandomTests : BaseRoutingStrategyTests
    {

        private Endpoint[] Endpoints
        {
            get { return new[] {Endpoint1, Endpoint2, Endpoint3, Endpoint4, Endpoint5}; }
        }

        protected override EndpointRoutingStrategy RoutingStrategy
        {
            get { return new RoutingStrategyRandom(); }
        }

        [Fact]
        public void ShouldSelectARandomEndpoint()
        {
            var order = new[] {3, 4, 2, 0, 1};
            var rand = new NotReallyRandom(order);
            var sut = CreateSut(new RoutingStrategyRandom(rand), Endpoints);

            foreach (var offset in order)
            {
                var expected = Endpoints[offset];

                var result = sut.GetEndpointUrl();
                result.Should().NotBeNull();
                result.ToString()
                      .Should()
                      .Be(expected.Uri.ToString());
            }
        }


        protected class NotReallyRandom : IRandom
        {
            private readonly int[] _values;

            private int _valueOffset = -1;

            public NotReallyRandom(params int[] values)
            {
                _values = values;
            }

            public int ValueOffset
            {
                get { return _valueOffset; }
                set { _valueOffset = value; }
            }

            public int Next()
            {
                ValueOffset = (ValueOffset + 1) % _values.Length;
                return _values[ValueOffset];
            }

            public int Next(int minValue, int maxValue)
            {
                throw new NotImplementedException();
            }

            public int Next(int maxValue)
            {
                return Next();
            }

            public void NextBytes(byte[] buffer)
            {
                throw new NotImplementedException();
            }

            public double NextDouble()
            {
                throw new NotImplementedException();
            }

        }

    }
}