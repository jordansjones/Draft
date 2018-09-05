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

        public TestingHttpClientFactory(Func<HttpTest, HttpRequestMessage, HttpResponseMessage> responseFactory = null)
        {
            _responseFactory = responseFactory ?? DefaultResponseFactory;
        }

        private HttpResponseMessage DefaultResponseFactory(HttpTest httpTest, HttpRequestMessage request)
        {
            throw new SocketException();
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            return new TestingMessageHandler(_responseFactory);
        }
    }

    public class TestingMessageHandler : HttpMessageHandler
    {

        private readonly Func<HttpTest, HttpRequestMessage, HttpResponseMessage> _responseFactory;

        public TestingMessageHandler(Func<HttpTest, HttpRequestMessage, HttpResponseMessage> responseFactory)
        {
            _responseFactory = responseFactory;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_responseFactory(HttpTest.Current, request));
        }

    }
}
