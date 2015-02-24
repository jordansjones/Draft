using System;
using System.Linq;

using Draft.Requests;

using Flurl;

namespace Draft
{
    internal class EtcdClient : IEtcdClient, IAtomicEtcdClient
    {

        public EtcdClient(Url endpointUrl)
        {
            EndpointUrl = endpointUrl;
            KeysUrl = EndpointUrl.AppendPathSegment(EtcdConstants.Path_Keys);
        }

        public Url EndpointUrl { get; private set; }

        public Url KeysUrl { get; private set; }

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

        public IUpsertKeyRequest UpsertKey(string keyPath)
        {
            return new UpsertQueueRequest(KeysUrl, keyPath);
        }

        public IWatchRequest Watch(string keyPath)
        {
            return new WatchRequest(KeysUrl, keyPath);
        }

        public IWatchRequest WatchOnce(string keyPath)
        {
            return new WatchRequest(KeysUrl, keyPath, true);
        }

    }
}
