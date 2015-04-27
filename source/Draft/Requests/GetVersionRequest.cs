using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses;

namespace Draft.Requests
{
    internal class GetVersionRequest : BaseRequest, IGetVersionRequest
    {

        public GetVersionRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts) {}

        public async Task<IEtcdVersion> Execute()
        {
            try
            {
                return await TargetUrl
                    .GetAsync()
                    .ReceiveJson<EtcdVersion>();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IEtcdVersion> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
