using System;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Flurl.Http.Testing;

namespace Draft.Tests
{
    public class TestingHttpClientFactory : TestHttpClientFactory
    {

        private readonly Func<HttpTest, HttpRequestMessage, HttpResponseMessage> _responseFactory;

        public TestingHttpClientFactory(HttpTest httpTest, Func<HttpTest, HttpRequestMessage, HttpResponseMessage> responseFactory = null)
            : base(httpTest)
        {
            HttpTest = httpTest;
            _responseFactory = responseFactory ?? DefaultResponseFactory;
        }

        public HttpTest HttpTest { get; private set; }

        public override HttpMessageHandler CreateMessageHandler()
        {
            return new TestingMessageHandler(HttpTest, _responseFactory);
        }

        private HttpResponseMessage DefaultResponseFactory(HttpTest httpTest, HttpRequestMessage request)
        {
            throw new SocketException();
        }

    }

    public class TestingMessageHandler : HttpMessageHandler
    {

        private readonly Func<HttpTest, HttpRequestMessage, HttpResponseMessage> _responseFactory;

        public TestingMessageHandler(HttpTest httpTest, Func<HttpTest, HttpRequestMessage, HttpResponseMessage> responseFactory)
        {
            HttpTest = httpTest;
            _responseFactory = responseFactory;
        }
        public HttpTest HttpTest { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_responseFactory(HttpTest, request));
        }

    }
}
