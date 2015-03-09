using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests.Cluster
{
    internal class DeleteMemberRequest : BaseRequest, IDeleteMemberRequest
    {

        public DeleteMemberRequest(IEtcdClient etcdClient, Url endpointUrl, string containerPath) : base(etcdClient, endpointUrl, containerPath) {}

        public string MemberId { get; private set; }

        public async Task Execute()
        {
            try
            {
                await TargetUrl
                    .AppendPathSegment(MemberId)
                    .DeleteAsync();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IDeleteMemberRequest WithMemberId(string memberId)
        {
            MemberId = memberId;
            return this;
        }

    }
}
