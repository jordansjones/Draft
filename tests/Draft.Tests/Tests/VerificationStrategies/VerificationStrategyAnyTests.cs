using System;

using FluentAssertions;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Exceptions;

using Xunit;

namespace Draft.Tests.VerificationStrategies
{
    public class VerificationStrategyAnyTests : BaseVerificationStrategyTests
    {

        protected override Uri[] Uris
        {
            get { return new[] {Uri1, Uri2, Uri3, Uri4, Uri5}; }
        }

        protected override EndpointVerificationStrategy VerificationStrategy
        {
            get { return new VerificationStrategyAny(); }
        }


        [Fact]
        public void ShouldThrowExceptionWhenNoEndpointsAreOnline()
        {
            using (InitializeInvalidHostHelper((xh, xr) => { throw new SocketException(); }))
            {
                Action action = () =>
                {
                    try
                    {
                        CreateSut(VerificationStrategy)
                            .VerifyAndBuild(Uris)
                            .Wait();
                    }
                    catch (AggregateException ae)
                    {
                        ExceptionDispatchInfo.Capture(ae.Flatten().InnerExceptions.First()).Throw();
                    }
                };
                
                action.ShouldThrow<InvalidHostException>();
            }
        }

        [Fact]
        public async Task ShouldSucceedIfSomeEndpointsAreOnline()
        {
            using (var http = InitializeInvalidHostHelper(
                (xh, xr) =>
                {
                    if (xr.RequestUri.ToString().StartsWith(Uri2.ToString()))
                    {
                        return xh.ResponseQueue.Any()
                            ? xh.ResponseQueue.Dequeue()
                            : new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent(string.Empty)
                            };
                    }
                    throw new SocketException();
                }))
            {
                http.RespondWith("etc 1.2.3");
                http.RespondWith("etc 1.2.3");
                http.RespondWith("etc 1.2.3");
                http.RespondWith("etc 1.2.3");
                http.RespondWith("etc 1.2.3");

                var epool = await CreateSut(VerificationStrategy)
                    .VerifyAndBuild(Uris);

                epool.Should().NotBeNull();

                epool.OnlineEndpoints.Should().HaveCount(1);
                var endpoint = epool.OnlineEndpoints.First();
                endpoint.Uri
                        .Should()
                        .BeSameAs(Uri2);
            }
        }

    }
}
