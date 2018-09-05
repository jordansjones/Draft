using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Draft.Endpoints;

using Flurl.Http;
using Flurl.Http.Testing;

namespace Draft.Tests.VerificationStrategies
{
    public abstract class BaseVerificationStrategyTests : IDisposable
    {

        protected static readonly Uri Uri1 = new Uri("http://localhost:1");

        protected static readonly Uri Uri2 = new Uri("http://localhost:2");

        protected static readonly Uri Uri3 = new Uri("http://localhost:3");

        protected static readonly Uri Uri4 = new Uri("http://localhost:4");

        protected static readonly Uri Uri5 = new Uri("http://localhost:5");

        protected Func<Task> BuildAndVerifyAction
        {
            get
            {
                return () => CreateSut().VerifyAndBuild(Uris);
            }
        }

        protected abstract Uri[] Uris { get; }

        protected abstract EndpointVerificationStrategy VerificationStrategy { get; }

        public void Dispose()
        {
            ResetInvalidHostHelper();
        }

        protected EndpointPool.Builder CreateSut(EndpointVerificationStrategy strategy = null)
        {
            return EndpointPool.Build()
                               .WithVerificationStrategy(strategy ?? VerificationStrategy);
        }

        protected HttpTest InitializeInvalidHostHelper(Func<HttpTest, HttpRequestMessage, HttpResponseMessage> responseFactory = null)
        {
            return new HttpTest().Configure(x => { x.HttpClientFactory = new TestingHttpClientFactory(responseFactory); });
        }

        protected void ResetInvalidHostHelper()
        {
            FlurlHttp.GlobalSettings.ResetDefaults();
        }

    }
}
