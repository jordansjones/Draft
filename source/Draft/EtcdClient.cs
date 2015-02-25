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

        public ICompareAndDeleteRequest CompareAndDelete(string keyPath)
        {
            throw new NotImplementedException();
        }

        public ICompareAndSwapRequest CompareAndSwap(string keyPath)
        {
            throw new NotImplementedException();
        }

        public IAtomicEtcdClient Atomic
        {
            get { return this; }
        }

        public ICreateDirectoryRequest CreateDirectory(string dirPath)
        {
            return new UpsertQueueRequest(KeysUrl, dirPath)
            {
                IsDirectory = true
            };
        }

        public IDeleteDirectoryRequest DeleteDirectory(string dirPath)
        {
            return new DeleteRequest(KeysUrl, dirPath, true);
        }

        public IDeleteKeyRequest DeleteKey(string keyPath)
        {
            return new DeleteRequest(KeysUrl, keyPath, false);
        }

        public IQueueRequest Enqueue(string keyPath)
        {
            return new UpsertQueueRequest(KeysUrl, keyPath)
            {
                IsQueue = true
            };
        }

        public IGetRequest Get(string path)
        {
            throw new NotImplementedException();
        }

        public IUpdateDirectoryRequest UpdateDirectory(string dirPath)
        {
            var request = new UpsertQueueRequest(KeysUrl, dirPath)
            {
                IsDirectory = true
            };

            request.WithExisting();

            return request;
        }

        public IUpsertKeyRequest UpsertKey(string keyPath)
        {
            return new UpsertQueueRequest(KeysUrl, keyPath);
        }

        public IWatchRequest Watch(string keyPath)
        {
            return new WatchRequest(KeysUrl, keyPath, false);
        }

        public IWatchRequest WatchOnce(string keyPath)
        {
            return new WatchRequest(KeysUrl, keyPath, true);
        }

    }
}
