using System;

using FluentAssertions;

using Flurl;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Draft.Exceptions;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Cluster
{
    public class GetLeaderTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Cluster.ClusterMemberResponse(new[] {Fixtures.EtcdUrl.ToUri()}, new[] {Fixtures.EtcdUrl.ToUri()}));

                var leader = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                                       .Cluster
                                       .GetLeader();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                                .AppendPathSegment(Constants.Etcd.Path_Members_Leader)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                leader.Should().NotBeNull();

                leader.PeerUrls.Should()
                      .NotBeEmpty()
                      .And
                      .ContainSingle(x => Fixtures.EtcdUrl.ToUri().Equals(x));

                leader.ClientUrls.Should()
                      .NotBeEmpty()
                      .And
                      .ContainSingle(x => Fixtures.EtcdUrl.ToUri().Equals(x));
            }
        }

        [Fact]
        public void ShouldThrowServiceUnavailableExceptionOn503ResponseCode()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(HttpStatusCode.ServiceUnavailable, string.Empty);

                Func<Task> action = async () =>
                {
                    await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                              .Cluster
                              .GetLeader();
                };

                action.ShouldThrowExactly<ServiceUnavailableException>()
                      .And
                      .IsServiceUnavailable.Should().BeTrue();
            }
        }

    }
}
