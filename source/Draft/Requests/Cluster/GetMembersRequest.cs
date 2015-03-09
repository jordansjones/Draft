using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

using Flurl;
using Flurl.Http;

namespace Draft.Requests.Cluster
{
    internal class GetMembersRequest : BaseRequest, IGetMembersRequest
    {

        public GetMembersRequest(IEtcdClient etcdClient, Url endpointUrl, string containerPath) : base(etcdClient, endpointUrl, containerPath) {}

        public async Task<IClusterMember[]> Execute()
        {
            try
            {
                var collection = await TargetUrl
                    .GetAsync()
                    .ReceiveJson<ClusterMemberCollection>();

                return collection.Members;
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IClusterMember[]> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
