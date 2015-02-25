using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests
{
    public class CompareAndSwapTests
    {

        [Fact]
        public async Task ExpectedIndex_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndSwap(Fixtures.CompareAndSwap.Path)
                    .WithExpectedIndex(Fixtures.CompareAndSwap.ExpectedIndex)
                    .WithNewValue(Fixtures.CompareAndSwap.NewValue);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.CompareAndSwap.Path)
                            .SetQueryParam(EtcdConstants.Parameter_PrevIndex, Fixtures.CompareAndSwap.ExpectedIndex)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.CompareAndSwap.DefaultRequest())
                    .Times(2);
            }
        }

        [Fact]
        public async Task ExpectedIndex_ShouldCallTheCorrectUrlWithTtlOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndSwap(Fixtures.CompareAndSwap.Path)
                    .WithExpectedIndex(Fixtures.CompareAndSwap.ExpectedIndex)
                    .WithNewValue(Fixtures.CompareAndSwap.NewValue)
                    .WithTimeToLive(Fixtures.CompareAndSwap.DefaultTtl);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.CompareAndSwap.Path)
                            .SetQueryParam(EtcdConstants.Parameter_PrevIndex, Fixtures.CompareAndSwap.ExpectedIndex)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.CompareAndSwap.TtlRequest())
                    .Times(2);
            }
        }

        [Fact]
        public async Task ExpectedValue_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndSwap(Fixtures.CompareAndSwap.Path)
                    .WithExpectedValue(Fixtures.CompareAndSwap.ExpectedValue)
                    .WithNewValue(Fixtures.CompareAndSwap.NewValue);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.CompareAndSwap.Path)
                            .SetQueryParam(EtcdConstants.Parameter_PrevValue, Fixtures.CompareAndSwap.ExpectedValue)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.CompareAndSwap.DefaultRequest())
                    .Times(2);
            }
        }

        [Fact]
        public async Task ExpectedValue_ShouldCallTheCorrectUrlWithTtlOption()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndSwap.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndSwap(Fixtures.CompareAndSwap.Path)
                    .WithExpectedValue(Fixtures.CompareAndSwap.ExpectedValue)
                    .WithNewValue(Fixtures.CompareAndSwap.NewValue)
                    .WithTimeToLive(Fixtures.CompareAndSwap.DefaultTtl);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(EtcdConstants.Path_Keys, Fixtures.CompareAndSwap.Path)
                            .SetQueryParam(EtcdConstants.Parameter_PrevValue, Fixtures.CompareAndSwap.ExpectedValue)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.CompareAndSwap.TtlRequest())
                    .Times(2);
            }
        }

    }
}
