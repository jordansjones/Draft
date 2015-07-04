using System;

using FluentAssertions;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Draft.Responses.Statistics;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Statistics
{
    public class GetSelfTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(Fixtures.Statistics.SelfResponse);

                var response = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Statistics
                    .GetServerStatistics();

                http.Should()
                    .HaveCalled(Fixtures.EtcdUrl.AppendPathSegment(Constants.Etcd.Path_Stats_Self))
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                response.Should().NotBeNull();
                response.Id.Should().NotBeNullOrWhiteSpace();
                response.Name.Should().NotBeNullOrWhiteSpace();

                response.LeaderInfo.Should().NotBeNull();
                response.LeaderInfo.Leader.Should().Be("8a69d5f6b7814500");
                response.LeaderInfo.StartTime.Should().HaveValue().And.NotBe(default(DateTime));
                response.LeaderInfo.Uptime.Should().NotBeNullOrWhiteSpace();

                response.State.Should().Be(StateType.StateFollower);
            }
        }

    }
}
