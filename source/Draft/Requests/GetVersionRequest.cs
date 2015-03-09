using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

using Flurl;
using Flurl.Http;

namespace Draft.Requests
{
    internal class GetVersionRequest : BaseRequest, IGetVersionRequest
    {


        public GetVersionRequest(IEtcdClient etcdClient, Url endpointUrl, string containerPath) : base(etcdClient, endpointUrl, containerPath) {}

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
