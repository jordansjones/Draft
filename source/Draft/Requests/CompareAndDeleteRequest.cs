using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class CompareAndDeleteRequest : BaseRequest, ICompareAndDeleteRequest, ICompareAndDeleteByIndexRequest, ICompareAndDeleteByValueRequest
    {

        public CompareAndDeleteRequest(Url endpointUrl, string path)
            : base(endpointUrl, path)
        {}

        public long ExpectedIndex { get; private set; }

        public string ExpectedValue { get; private set; }

        Task<object> ICompareAndDeleteByIndexRequest.Execute()
        {
            return Execute(false);
        }

        TaskAwaiter<object> ICompareAndDeleteByIndexRequest.GetAwaiter()
        {
            return GetAwaiter(false);
        }

        ICompareAndDeleteByIndexRequest ICompareAndDeleteByIndexRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        Task<object> ICompareAndDeleteByValueRequest.Execute()
        {
            return Execute(true);
        }

        TaskAwaiter<object> ICompareAndDeleteByValueRequest.GetAwaiter()
        {
            return GetAwaiter(true);
        }

        ICompareAndDeleteByValueRequest ICompareAndDeleteByValueRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
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

        private async Task<object> Execute(bool isByValue)
        {
            return await TargetUrl
                .Conditionally(isByValue, x => x.SetQueryParam(EtcdConstants.Parameter_PrevValue, ExpectedValue))
                .Conditionally(!isByValue, x => x.SetQueryParam(EtcdConstants.Parameter_PrevIndex, ExpectedIndex))
                .DeleteAsync(CancellationToken)
                .ReceiveJson();
        }

        private TaskAwaiter<object> GetAwaiter(bool isByValue)
        {
            return Execute(isByValue).GetAwaiter();
        }

    }
}
