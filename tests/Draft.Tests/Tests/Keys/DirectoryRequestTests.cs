using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Draft.Constants;

using Flurl;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Keys
{
    public class DirectoryRequestTests
    {

        [Fact]
        public async Task Create_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .CreateDirectory(Fixtures.Directory.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(Constants.Etcd.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Directory.DefaultRequest.AsRequestBody())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Create_ShouldCallTheCorrectUrlWithTimeToLiveOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .CreateDirectory(Fixtures.Directory.Path)
                    .WithTimeToLive(Fixtures.Directory.DefaultTtl);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(Constants.Etcd.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(
                        Fixtures.Directory.DefaultRequest
                            .Add(Constants.Etcd.Parameter_Ttl, Fixtures.Directory.DefaultTtl)
                            .AsRequestBody()
                    )
                    .Times(1);
            }
        }

        [Fact]
        public async Task Delete_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .DeleteDirectory(Fixtures.Directory.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Directory.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Delete_ShouldCallTheCorrectUrlWithRecursiveFalseOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .DeleteDirectory(Fixtures.Directory.Path)
                    .WithRecursive(false);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Directory.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Delete_ShouldCallTheCorrectUrlWithRecursiveTrueOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .DeleteDirectory(Fixtures.Directory.Path)
                    .WithRecursive(true);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Directory.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True)
                            .SetQueryParam(Constants.Etcd.Parameter_Recursive, Constants.Etcd.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpdateDirectory(Fixtures.Directory.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(Constants.Etcd.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Directory.WithExistingRequest.AsRequestBody())
                    .Times(1);
            }
        }

        [Fact]
        public async Task Update_ShouldCallTheCorrectUrlWithTimeToLiveOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpdateDirectory(Fixtures.Directory.Path)
                    .WithTimeToLive(Fixtures.Directory.DefaultTtl);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(Constants.Etcd.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(
                        Fixtures.Directory.WithExistingRequest
                            .Add(Constants.Etcd.Parameter_Ttl, Fixtures.Directory.DefaultTtl)
                            .AsRequestBody()
                    )
                    .Times(1);
            }
        }


    }
}
