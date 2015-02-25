using System;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests
{
    public class KeyRequestTests
    {

        [Fact]
        public async Task Delete_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .DeleteKey(Fixtures.Key.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Get_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Get_ShouldCallTheCorrectUrlWithQuorumFalseOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path)
                    .WithQuorum(false);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Get_ShouldCallTheCorrectUrlWithQuorumTrueOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path)
                    .WithQuorum();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Quorum, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Get_ShouldCallTheCorrectUrlWithRecursiveFalseOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path)
                    .WithRecursive(false);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Get_ShouldCallTheCorrectUrlWithRecursiveTrueOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path)
                    .WithRecursive();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(Fixtures.Key.DefaultValue);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.DefaultRequest())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlWithExistingFalseOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(Fixtures.Key.DefaultValue)
                    .WithExisting(false);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.ExistingRequest(existing : false))
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlWithExistingTrueOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(Fixtures.Key.DefaultValue)
                    .WithExisting();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.ExistingRequest())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlWithTtlOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(Fixtures.Key.DefaultValue)
                    .WithTimeToLive(Fixtures.Key.DefaultTtl);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.TtlRequest())
                    .Times(1);
            }
        }

    }
}
