using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;

using Flurl;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Cluster
{
    public class GetHealthTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            var expected = true;
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Cluster.ClusterHealthResponse(expected));

                var healthResult = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Cluster
                    .GetHealth();

                http.Should()
                    .HaveCalled(Fixtures.EtcdUrl.AppendPathSegment(Constants.Etcd.Path_Health))
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                healthResult.Should().NotBeNull();

                healthResult.Value.Should()
                    .Be(expected);
            }
        }

    }
}
