using System;
using System.Linq;
using System.Net.Http;

using Draft.Models;

namespace Draft.Responses
{
    internal class RawEtcdResponse
    {

        public RawEtcdResponse(ResponseHeaders responseHeaders, HttpResponseMessage responseMessage)
        {
            ResponseHeaders = responseHeaders;
            ResponseMessage = responseMessage;
        }

        public ResponseHeaders ResponseHeaders { get; private set; }

        public HttpResponseMessage ResponseMessage { get; private set; }

    }
}
