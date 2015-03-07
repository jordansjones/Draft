using System.Net.Http;
using System.Net.Sockets;

using Flurl.Http.Configuration;
using Flurl.Http.Testing;

namespace Draft.Tests
{
    public class InvalidHostExceptionTestClientFactory : DefaultHttpClientFactory
    {

        public override HttpMessageHandler CreateMessageHandler()
        {
            return new FakeHttpMessageHandler(() => { throw new SocketException(); });
        }

    }
}