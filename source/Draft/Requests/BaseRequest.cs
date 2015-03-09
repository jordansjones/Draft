using System;
using System.Linq;

using Flurl;

namespace Draft.Requests
{
    internal abstract class BaseRequest
    {

        private readonly string _containerPath;

        private readonly Url _endpointUrl;

        protected BaseRequest(IEtcdClient etcdClient, Url endpointUrl, string containerPath)
        {
            EtcdClient = etcdClient;
            _endpointUrl = endpointUrl;
            _containerPath = containerPath;
        }

        public IEtcdClient EtcdClient { get; private set; }

        public Url TargetUrl
        {
            get { return new Url(_endpointUrl).AppendPathSegment(_containerPath); }
        }

    }
}
