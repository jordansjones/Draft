using System;
using System.Linq;

using Flurl;

namespace Draft.Requests
{
    internal abstract class BaseRequest
    {

        private readonly Url _endpointUrl;

        private readonly string _containerPath;

        protected BaseRequest(IEtcdClient client, Url endpointUrl, string containerPath)
        {
            Client = client;
            _endpointUrl = endpointUrl;
            _containerPath = containerPath;
        }

        public Url TargetUrl
        {
            get { return new Url(_endpointUrl).AppendPathSegment(_containerPath); }
        }

        public IEtcdClient Client { get; private set; }

    }
}
