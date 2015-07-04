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
    public class GetStoreTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(Fixtures.Statistics.StoreResponse);

                var response = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Statistics
                    .GetStoreStatistics();

                http.Should()
                    .HaveCalled(Fixtures.EtcdUrl.AppendPathSegment(Constants.Etcd.Path_Stats_Store))
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                response.Should().NotBeNull();
                response.CreateSuccess.Should().Be(2);
                response.GetsFail.Should().Be(4);
                response.GetsSuccess.Should().Be(75);
                response.SetsFail.Should().Be(2);
                response.SetsSuccess.Should().Be(4);
                response.CompareAndDeleteFail.Should().Be(0);
                response.CompareAndDeleteSuccess.Should().Be(0);
                response.CompareAndSwapFail.Should().Be(0);
                response.CompareAndSwapSuccess.Should().Be(0);
                response.DeleteSuccess.Should().Be(0);
                response.DeleteFail.Should().Be(0);
                response.ExpireCount.Should().Be(0);
                response.Watchers.Should().Be(0);
            }
        }

    }
}
