using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

using Flurl;

namespace Draft.Requests
{
    internal class CompareAndDeleteRequest : BaseRequest, ICompareAndDeleteRequest, ICompareAndDeleteByIndexRequest, ICompareAndDeleteByValueRequest
    {

        public CompareAndDeleteRequest(IEtcdClient etcdClient, Url endpointUrl, string containerPath)
            : base(etcdClient, endpointUrl, containerPath) {}

        public long ExpectedIndex { get; private set; }

        public string ExpectedValue { get; private set; }

        Task<IKeyEvent> ICompareAndDeleteByIndexRequest.Execute()
        {
            return Execute(false);
        }

        TaskAwaiter<IKeyEvent> ICompareAndDeleteByIndexRequest.GetAwaiter()
        {
            return GetAwaiter(false);
        }

        Task<IKeyEvent> ICompareAndDeleteByValueRequest.Execute()
        {
            return Execute(true);
        }

        TaskAwaiter<IKeyEvent> ICompareAndDeleteByValueRequest.GetAwaiter()
        {
            return GetAwaiter(true);
        }

        public ICompareAndDeleteByIndexRequest WithExpectedIndex(long modifiedIndex)
        {
            ExpectedIndex = modifiedIndex;
            return this;
        }

        public ICompareAndDeleteByValueRequest WithExpectedValue(string value)
        {
            ExpectedValue = value;
            return this;
        }

        private async Task<IKeyEvent> Execute(bool isByValue)
        {
            try
            {
                return await TargetUrl
                    .Conditionally(isByValue, x => x.SetQueryParam(Constants.Etcd.Parameter_PrevValue, ExpectedValue))
                    .Conditionally(!isByValue, x => x.SetQueryParam(Constants.Etcd.Parameter_PrevIndex, ExpectedIndex))
                    .DeleteAsync()
                    .ReceiveEtcdResponse<KeyEvent>(EtcdClient);
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        private TaskAwaiter<IKeyEvent> GetAwaiter(bool isByValue)
        {
            return Execute(isByValue).GetAwaiter();
        }

    }
}
