using System;

using FluentAssertions;

using System.Linq;
using System.Threading.Tasks;

using Draft.Endpoints;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.VerificationStrategies
{
    public class VerificationStrategyNoneTests : BaseVerificationStrategyTests
    {

        protected override Uri[] Uris
        {
            get { return new[] {Uri1, Uri2, Uri3, Uri4, Uri5}; }
        }

        protected override EndpointVerificationStrategy VerificationStrategy
        {
            get { return new VerificationStrategyNone(); }
        }

        [Fact]
        public void ShouldVerifyAndBuildWithoutException()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith("etcd 1.2.3")
                    .RespondWith("etcd 1.2.3")
                    .RespondWith("etcd 1.2.4")
                    .RespondWith("etcd 1.2.4")
                    .RespondWith("etcd 1.2.4");

                BuildAndVerifyAction.Should().NotThrow<Exception>();
            }
        }

        [Fact]
        public async Task ShouldMarkAllAsOnline()
        {
            var results = await CreateSut().VerifyAndBuild(Uris);

            results.Should().NotBeNull();
            results.AllEndpoints
                   .Should()
                   .HaveSameCount(Uris);

            foreach (var endpoint in results.AllEndpoints)
            {
                endpoint.Availability.Should()
                        .Be(EndpointAvailability.Online);
            }
        }

    }
}
