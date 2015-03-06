using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Atomics
{
    public class CompareAndDeleteTests
    {

        [Fact]
        public async Task ExpectedIndex_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndDelete.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndDelete.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndDelete(Fixtures.CompareAndDelete.Path)
                    .WithExpectedIndex(Fixtures.CompareAndDelete.ExpectedIndex);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.CompareAndDelete.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_PrevIndex, Fixtures.CompareAndDelete.ExpectedIndex)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(2);
            }
        }

        [Fact]
        public async Task ExpectedValue_ShouldCallTheCorrectUrlByAwaitingImmediately()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.CompareAndDelete.DefaultResponse)
                    .RespondWithJson(Fixtures.CompareAndDelete.DefaultResponse);

                var req = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Atomic.CompareAndDelete(Fixtures.CompareAndDelete.Path)
                    .WithExpectedValue(Fixtures.CompareAndDelete.ExpectedValue);

                await req;
                await req.Execute();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.CompareAndDelete.Path)
                            .SetQueryParam(Constants.Etcd.Parameter_PrevValue, Fixtures.CompareAndDelete.ExpectedValue)
                    )
                    .WithVerb(HttpMethod.Delete)
                    .Times(2);
            }
        }

    }
}
