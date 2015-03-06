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
    public class CreateMemberTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Cluster.CreateResponse(Fixtures.EtcdUrl.ToUri()));

                var member = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Cluster
                    .CreateMember()
                    .WithPeerUri(Fixtures.EtcdUrl.ToUri());

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                        .AppendPathSegment(Constants.Etcd.Path_Members)
                    )
                    .WithVerb(HttpMethod.Post)
                    .Times(1);

                member.Should().NotBeNull();

                member.PeerUrls.Should()
                    .NotBeEmpty()
                    .And
                    .ContainSingle(x => Fixtures.EtcdUrl.ToUri().Equals(x));
            }
        }

    }
}
