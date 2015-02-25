using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class CompareAndSwapRequest : BaseRequest, ICompareAndSwapRequest, ICompareAndSwapByIndexRequest, ICompareAndSwapByValueRequest
    {

        public CompareAndSwapRequest(Url endpointUrl, string path)
            : base(endpointUrl, path)
        {}

        public long ExpectedIndex { get; private set; }

        public string ExpectedValue { get; private set; }

        public long? Ttl { get; private set; }

        public string Value { get; private set; }

        Task<object> ICompareAndSwapByIndexRequest.Execute()
        {
            return Execute(false);
        }

        TaskAwaiter<object> ICompareAndSwapByIndexRequest.GetAwaiter()
        {
            return GetAwaiter(false);
        }

        ICompareAndSwapByIndexRequest ICompareAndSwapByIndexRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        ICompareAndSwapByIndexRequest ICompareAndSwapByIndexRequest.WithNewValue(string value)
        {
            WithNewValue(value);
            return this;
        }

        ICompareAndSwapByIndexRequest ICompareAndSwapByIndexRequest.WithTimeToLive(long? seconds)
        {
            WithTimeToLive(seconds);
            return this;
        }

        Task<object> ICompareAndSwapByValueRequest.Execute()
        {
            return Execute(true);
        }

        TaskAwaiter<object> ICompareAndSwapByValueRequest.GetAwaiter()
        {
            return GetAwaiter(true);
        }

        ICompareAndSwapByValueRequest ICompareAndSwapByValueRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        ICompareAndSwapByValueRequest ICompareAndSwapByValueRequest.WithNewValue(string value)
        {
            WithNewValue(value);
            return this;
        }

        ICompareAndSwapByValueRequest ICompareAndSwapByValueRequest.WithTimeToLive(long? seconds)
        {
            WithTimeToLive(seconds);
            return this;
        }

        public ICompareAndSwapByIndexRequest WithExpectedIndex(long modifiedIndex)
        {
            ExpectedIndex = modifiedIndex;
            return this;
        }

        public ICompareAndSwapByValueRequest WithExpectedValue(string value)
        {
            ExpectedValue = value;
            return this;
        }

        private async Task<object> Execute(bool isByValue)
        {
            var values = new ListDictionary
            {
                {
                    // Key
                    EtcdConstants.Parameter_Value,
                    // Value
                    Value
                }
            };

            if (Ttl.HasValue)
            {
                values.Add(EtcdConstants.Parameter_Ttl, Ttl.Value);
            }

            return await TargetUrl
                .Conditionally(isByValue, x => x.SetQueryParam(EtcdConstants.Parameter_PrevValue, ExpectedValue))
                .Conditionally(!isByValue, x => x.SetQueryParam(EtcdConstants.Parameter_PrevIndex, ExpectedIndex))
                .PutUrlEncodedAsync(values, CancellationToken)
                .ReceiveJson();
        }

        private TaskAwaiter<object> GetAwaiter(bool isByValue)
        {
            return Execute(isByValue).GetAwaiter();
        }

        private void WithNewValue(string value)
        {
            Value = value;
        }

        private void WithTimeToLive(long? seconds)
        {
            Ttl = seconds;
        }

    }
}
