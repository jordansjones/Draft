using System;
using System.Linq;

using Draft.Configuration;
using Draft.Endpoints;
using Draft.Requests;
using Draft.Requests.Cluster;
using Draft.Requests.Statistics;

namespace Draft
{
    /// <summary>
    ///     Etcd client.
    /// </summary>
    public interface IEtcdClient
    {

        /// <summary>
        ///     Returns an etcd client for atomic operations.
        /// </summary>
        IAtomicEtcdClient Atomic { get; }

        /// <summary>
        ///     Returns an etcd client for cluster related operations.
        /// </summary>
        IClusterEtcdClient Cluster { get; }

        /// <summary>
        ///     <see cref="IEtcdClient" />'s instance configuration options.
        /// </summary>
        IEtcdClientConfig Config { get; }

        /// <summary>
        ///     Returns an etcd client for statistics related operations.
        /// </summary>
        IStatisticsEtcdClient Statistics { get; }

        /// <summary>
        ///     Provides thread-safe access to this instance's configuration options.
        /// </summary>
        void Configure(Action<IMutableEtcdClientConfig> configAction);

        /// <summary>
        ///     Begins a directory creation request.
        /// </summary>
        ICreateDirectoryRequest CreateDirectory(string key);

        /// <summary>
        ///     Begins a directory deletion request.
        /// </summary>
        IDeleteDirectoryRequest DeleteDirectory(string key);

        /// <summary>
        ///     Begins a key deletion request.
        /// </summary>
        IDeleteKeyRequest DeleteKey(string key);

        /// <summary>
        ///     Begins a key retrieval request.
        /// </summary>
        IGetRequest GetKey(string key);

        /// <summary>
        ///     Begins a version retrieval request.
        /// </summary>
        IGetVersionRequest GetVersion();

        /// <summary>
        ///     Begins a directory update request.
        /// </summary>
        /// <remarks>
        ///     <para>Primarily used for updating TTL.</para>
        /// </remarks>
        IUpdateDirectoryRequest UpdateDirectory(string key);

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

        /// <summary>
        ///     Begins an atomic enqueue key request.
        /// </summary>
        IQueueRequest Enqueue(string key);

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

    /// <summary>
    ///     Etcd client for statistics related operations.
    /// </summary>
    public interface IStatisticsEtcdClient
    {

        /// <summary>
        ///     Begins a request to retrieve the statistical information for the leader in an etcd cluster.
        /// </summary>
        IGetLeaderStatisticsRequest GetLeaderStatistics();

        /// <summary>
        ///     Begins a request to retrieve the statistical information for the server.
        /// </summary>
        /// <remarks>Which server depends on how the <see cref="EndpointPool" /> was built.</remarks>
        IGetServerStatisticsRequest GetServerStatistics();

        /// <summary>
        ///     Begins a request to retrieve the etcd backing store statistics.
        /// </summary>
        /// <remarks>For which server depends on how the <see cref="EndpointPool" /> was built.</remarks>
        IGetStoreStatisticsRequest GetStoreStatistics();

    }
}
