using System;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using FluentAssertions;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Cluster
{
    public class UpdateMemberPeerUrlsTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(
                    Fixtures.Cluster.ClusterMemberResponse(
                        peerUris : new[]
                        {
                            Fixtures.EtcdUrl.ToUri(),
                            Fixtures.EtcdUrl.ToUri()
                        }));

                var memberId = StaticRandom.Instance.Next().ToString();

                var member = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                                       .Cluster
                                       .UpdateMemberPeerUrls()
                                       .WithMemberId(memberId)
                                       .WithPeerUri(Fixtures.EtcdUrl.ToUri(), Fixtures.EtcdUrl.ToUri());

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                                .AppendPathSegment(Constants.Etcd.Path_Members)
                                .AppendPathSegment(memberId)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithContentType(Constants.Http.ContentType_ApplicationJson)
                    .Times(1);

                member.Should().NotBeNull();
                member.PeerUrls
                      .Should()
                      .HaveCount(2)
                      .And
                      .ContainInOrder(
                          Fixtures.EtcdUrl.ToUri(),
                          Fixtures.EtcdUrl.ToUri()
                    );
            }
        }

    }
}
