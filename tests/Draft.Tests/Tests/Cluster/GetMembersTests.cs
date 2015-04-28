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
    public class GetMembersTests
    {

        [Fact]
        public async Task ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(
                    Fixtures.Cluster.ClusterMembersResponse(
                        Fixtures.Cluster.ClusterMemberResponse(),
                        Fixtures.Cluster.ClusterMemberResponse(),
                        Fixtures.Cluster.ClusterMemberResponse(),
                        Fixtures.Cluster.ClusterMemberResponse(),
                        Fixtures.Cluster.ClusterMemberResponse()
                        ));

                var members = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                                        .Cluster
                                        .GetMembers();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                                .AppendPathSegment(Constants.Etcd.Path_Members)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                members.Should().NotBeNull()
                       .And
                       .HaveCount(5);
            }
        }

    }
}
