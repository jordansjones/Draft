using System;
using System.Linq;

using Draft.Requests;
using Draft.Requests.Cluster;

namespace Draft
{
    /// <summary>
    ///     Etcd client.
    /// </summary>
    public interface IEtcdClient
    {

        /// <summary>
        ///     Returns an Etcd client for atomic operations.
        /// </summary>
        IAtomicEtcdClient Atomic { get; }

        /// <summary>
        ///     Returns an Etcd cluent for cluster related operations.
        /// </summary>
        IClusterEtcdClient Cluster { get; }

        /// <summary>
        ///     Begins a directory creation request.
        /// </summary>
        ICreateDirectoryRequest CreateDirectory(string path);

        /// <summary>
        ///     Begins a directory deletion request.
        /// </summary>
        IDeleteDirectoryRequest DeleteDirectory(string path);

        /// <summary>
        ///     Begins a key deletion request.
        /// </summary>
        IDeleteKeyRequest DeleteKey(string key);

        /// <summary>
        ///     Begins an enqueue key request.
        /// </summary>
        IQueueRequest Enqueue(string key);

        /// <summary>
        ///     Begins a key retrieval request.
        /// </summary>
        IGetRequest GetKey(string key);

        /// <summary>
        ///     Begins a directory update request.
        /// </summary>
        /// <remarks>
        ///     <para>Primarily used for updating TTL.</para>
        /// </remarks>
        IUpdateDirectoryRequest UpdateDirectory(string path);

        /// <summary>
        ///     Begins a key update request.
        /// </summary>
        IUpsertKeyRequest UpsertKey(string key);

        /// <summary>
        ///     Begins a key watch request.
        /// </summary>
        /// <remarks>
        ///     <para>This will continue watching until the observable's subscription is disposed.</para>
        /// </remarks>
        IWatchRequest Watch(string key);

        /// <summary>
        ///     Begins a key watch request.
        /// </summary>
        /// <remarks>
        ///     <para>This will watch a key until the first key event occurs.</para>
        /// </remarks>
        IWatchRequest WatchOnce(string key);

    }

    /// <summary>
    ///     Etcd client for atomic operations.
    /// </summary>
    public interface IAtomicEtcdClient
    {

        /// <summary>
        ///     Begins an atomic key deletion request.
        /// </summary>
        ICompareAndDeleteRequest CompareAndDelete(string key);

        /// <summary>
        ///     Begins an atomic key update request.
        /// </summary>
        ICompareAndSwapRequest CompareAndSwap(string key);

    }

    /// <summary>
    ///     Etcd client for cluster related operations.
    /// </summary>
    public interface IClusterEtcdClient
    {

        /// <summary>
        ///     Begins a member creation request.
        /// </summary>
        ICreateMemberRequest CreateMember();

        /// <summary>
        ///     Begins a member deletion request.
        /// </summary>
        IDeleteMemberRequest DeleteMember();

        /// <summary>
        ///     Begins a leader retrieval request.
        /// </summary>
        IGetLeaderRequest GetLeader();

        /// <summary>
        ///     Begins a members retrieval request.
        /// </summary>
        IGetMembersRequest GetMembers();

        /// <summary>
        ///     Begins an update member peer urls request.
        /// </summary>
        IUpdateMemberPeerUrlsRequest UpdateMemberPeerUrls();

    }
}
