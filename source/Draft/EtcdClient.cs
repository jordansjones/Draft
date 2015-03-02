using System;
using System.Linq;

using Draft.Requests;

using Flurl;

namespace Draft
{
    internal class EtcdClient : IEtcdClient, IAtomicEtcdClient
    {

        private readonly Url _keysUrl;

        public EtcdClient(Url endpointUrl)
        {
            EndpointUrl = endpointUrl;
            _keysUrl = EndpointUrl.AppendPathSegment(EtcdConstants.Path_Keys);
        }

        public Url EndpointUrl { get; private set; }

        public Url KeysUrl
        {
            get { return new Url(_keysUrl); }
        }

        public ICompareAndDeleteRequest CompareAndDelete(string key)
        {
            return new CompareAndDeleteRequest(KeysUrl, key);
        }

        public ICompareAndSwapRequest CompareAndSwap(string key)
        {
            return new CompareAndSwapRequest(KeysUrl, key);
        }

        public IAtomicEtcdClient Atomic
        {
            get { return this; }
        }

        public ICreateDirectoryRequest CreateDirectory(string path)
        {
            return new UpsertQueueRequest(KeysUrl, path)
            {
                IsDirectory = true
            };
        }

        public IDeleteDirectoryRequest DeleteDirectory(string path)
        {
            return new DeleteRequest(KeysUrl, path, true);
        }

        public IDeleteKeyRequest DeleteKey(string key)
        {
            return new DeleteRequest(KeysUrl, key, false);
        }

        public IQueueRequest Enqueue(string key)
        {
            return new UpsertQueueRequest(KeysUrl, key)
            {
                IsQueue = true
            };
        }

        public IGetRequest GetKey(string key)
        {
            return new GetRequest(KeysUrl, key);
        }

        public IUpdateDirectoryRequest UpdateDirectory(string path)
        {
            var request = new UpsertQueueRequest(KeysUrl, path)
            {
                IsDirectory = true
            };

            request.WithExisting();

            return request;
        }

        public IUpsertKeyRequest UpsertKey(string key)
        {
            return new UpsertQueueRequest(KeysUrl, key);
        }

        public IWatchRequest Watch(string key)
        {
            return new WatchRequest(KeysUrl, key, false);
        }

        public IWatchRequest WatchOnce(string key)
        {
            return new WatchRequest(KeysUrl, key, true);
        }

    }
}
