using System;

using FluentAssertions;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Statistics
{
    public class GetLeaderTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(Fixtures.Statistics.LeaderResponse);

                var response = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Statistics
                    .GetLeaderStatistics();

                http.Should()
                    .HaveCalled(Fixtures.EtcdUrl.AppendPathSegment(Constants.Etcd.Path_Stats_Leader))
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                response.Should().NotBeNull();

                response.Leader.Should().NotBeNullOrWhiteSpace();
                response.Followers.Should().NotBeNull()
                    .And.HaveCount(2);
                response.Followers.Keys.OrderBy(x => x).Should()
                    .HaveCount(2)
                    .And.ContainInOrder("6e3bd23ae5f1eae0", "a8266ecf031671f3");
            }
        }

    }
}
