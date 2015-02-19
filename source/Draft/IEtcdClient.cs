using System;
using System.Linq;

using Draft.Requests;

namespace Draft
{
    public interface IEtcdClient
    {

        IAtomicEtcdClient Atomic { get; }

        ICreateDirectoryRequest CreateDirectory(string dirPath);

        IDeleteDirectoryRequest DeleteDirectory(string dirPath);

        IDeleteKeyRequest DeleteKey(string keyPath);

        IQueueRequest Enqueue(string keyPath);

        IGetRequest Get(string path);

        IUpsertKeyRequest UpsertKey(string keyPath);

        IWatchRequest Watch(string keyPath);

    }

    public interface IAtomicEtcdClient
    {

        ICompareAndDeleteRequest CompareAndDelete(string keyPath);

        ICompareAndSwapRequest CompareAndSwap(string keyPath);

    }
}
