using System;
using System.Linq;
using System.Threading;

using Flurl;

namespace Draft.Requests
{
    internal abstract class BaseRequest
    {

        private readonly Url _endpointUrl;

        private readonly string _keyPath;

        protected BaseRequest(Url endpointUrl, string keyPath)
        {
            _endpointUrl = endpointUrl;
            _keyPath = keyPath;
        }

        public Url TargetUrl
        {
            get { return new Url(_endpointUrl).AppendPathSegment(_keyPath); }
        }

        public CancellationToken? CancellationToken { get; protected set; }


    }
}
