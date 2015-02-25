using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class UpsertQueueRequest : IUpsertKeyRequest, ICreateDirectoryRequest, IUpdateDirectoryRequest, IQueueRequest
    {

        public UpsertQueueRequest(Url endpointUrl, string path)
        {
            EndpointUrl = endpointUrl;
            Path = path;
        }

        public CancellationToken? CancellationToken { get; private set; }

        public Url EndpointUrl { get; private set; }

        public bool? Existing { get; private set; }

        public bool IsDirectory { get; set; }

        public bool IsQueue { get; set; }

        public string Path { get; private set; }

        public long? Ttl { get; private set; }

        public string Value { get; private set; }

        ICreateDirectoryRequest ICreateDirectoryRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        ICreateDirectoryRequest ICreateDirectoryRequest.WithTimeToLive(long? seconds)
        {
            WithTimeToLive(seconds);
            return this;
        }

        IQueueRequest IQueueRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
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

        IUpdateDirectoryRequest IUpdateDirectoryRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        IUpdateDirectoryRequest IUpdateDirectoryRequest.WithTimeToLive(long? seconds)
        {
            WithExisting();
            WithTimeToLive(seconds);
            return this;
        }

        public async Task<object> Execute()
        {
            var values = new ListDictionary
            {
                {
                    // Key
                    IsDirectory ? EtcdConstants.Parameter_Directory : EtcdConstants.Parameter_Value,
                    // Value
                    IsDirectory ? EtcdConstants.Parameter_True : Value
                }
            };

            if (Existing.HasValue)
            {
                values.Add(EtcdConstants.Parameter_PrevExist, Existing.Value ? EtcdConstants.Parameter_True : EtcdConstants.Parameter_False);
            }

            if (Ttl.HasValue)
            {
                values.Add(EtcdConstants.Parameter_Ttl, Ttl.Value);
            }

            return await EndpointUrl
                .AppendPathSegment(Path)
                .Conditionally(IsQueue, values, (x, v) => x.PostUrlEncodedAsync(v, CancellationToken), (x, v) => x.PutUrlEncodedAsync(v, CancellationToken))
                .ReceiveJson();
        }

        public TaskAwaiter<object> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        IUpsertKeyRequest IUpsertKeyRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
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
