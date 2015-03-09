using System;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Newtonsoft.Json;

using Xunit;

namespace Draft.Tests.Keys
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_Quorum, Constants.Etcd.Parameter_True)
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_Recursive, Constants.Etcd.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldCallTheCorrectUrlByAwaitingImmediately()
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.DefaultRequest())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldCallTheCorrectUrlWithExistingFalseOption()
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.ExistingRequest(existing : false))
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldCallTheCorrectUrlWithExistingTrueOption()
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.ExistingRequest())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldCallTheCorrectUrlWithTtlOption()
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
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.TtlRequest())
                    .Times(1);
            }
        }

    }
}
