using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses;

namespace Draft.Requests
{
    internal class UpsertQueueRequest : BaseRequest, IUpsertKeyRequest, ICreateDirectoryRequest, IUpdateDirectoryRequest, IQueueRequest
    {

        public UpsertQueueRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts) {}

        public bool? Existing { get; private set; }

        public bool IsDirectory { get; set; }

        public bool IsQueue { get; set; }

        public long? Ttl { get; private set; }

        public string Value { get; private set; }

        ICreateDirectoryRequest ICreateDirectoryRequest.WithTimeToLive(long? seconds)
        {
            WithTimeToLive(seconds);
            return this;
        }

        IQueueRequest IQueueRequest.WithTimeToLive(long? seconds)
        {
            WithTimeToLive(seconds);
            return this;
        }

        IQueueRequest IQueueRequest.WithValue(string value)
        {
            WithValue(value);
            return this;
        }

        IUpdateDirectoryRequest IUpdateDirectoryRequest.WithTimeToLive(long? seconds)
        {
            WithExisting();
            WithTimeToLive(seconds);
            return this;
        }

        public async Task<IKeyEvent> Execute()
        {
            var values = new FormBodyBuilder()
                .Add(
                    IsDirectory ? Constants.Etcd.Parameter_Directory : Constants.Etcd.Parameter_Value,
                    IsDirectory ? Constants.Etcd.Parameter_True : Value
                )
                // ReSharper disable once PossibleInvalidOperationException
                .Add(Existing.HasValue, Constants.Etcd.Parameter_PrevExist, () => Existing.Value ? Constants.Etcd.Parameter_True : Constants.Etcd.Parameter_False)
                // ReSharper disable once PossibleInvalidOperationException
                .Add(Ttl.HasValue, Constants.Etcd.Parameter_Ttl, () => Ttl.Value)
                .Build();

            try
            {
                return await TargetUrl
                    .Conditionally(IsQueue, values, (x, v) => x.PostUrlEncodedAsync(v), (x, v) => x.PutUrlEncodedAsync(v))
                    .ReceiveEtcdResponse<KeyEvent>(EtcdClient);
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IKeyEvent> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IUpsertKeyRequest WithExisting(bool existing = true)
        {
            Existing = existing;
            return this;
        }

        public IUpsertKeyRequest WithTimeToLive(long? seconds)
        {
            Ttl = seconds;
            return this;
        }

        public IUpsertKeyRequest WithValue(string value)
        {
            Value = value;
            return this;
        }

    }
}
