using System;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests
{
    public class DirectoryRequestTests
    {

        [Fact]
        public async Task CreateDirectory_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .CreateDirectory(Fixtures.Directory.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Directory.DefaultRequest.AsRequestBody())
                    .Times(1);
            }
        }

        [Fact]
        public async Task CreateDirectory_ShouldCallTheCorrectUrlWithTimeToLiveOption()
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
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(
                        Fixtures.Directory.DefaultRequest
                            .Add(EtcdConstants.Parameter_Ttl, Fixtures.Directory.DefaultTtl)
                            .AsRequestBody()
                    )
                    .Times(1);
            }
        }

        [Fact]
        public async Task UpdateDirectory_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Directory.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpdateDirectory(Fixtures.Directory.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Directory.WithExistingRequest.AsRequestBody())
                    .Times(1);
            }
        }

        [Fact]
        public async Task UpdateDirectory_ShouldCallTheCorrectUrlWithTimeToLiveOption()
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
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Directory.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(
                        Fixtures.Directory.WithExistingRequest
                            .Add(EtcdConstants.Parameter_Ttl, Fixtures.Directory.DefaultTtl)
                            .AsRequestBody()
                    )
                    .Times(1);
            }
        }


    }
}
