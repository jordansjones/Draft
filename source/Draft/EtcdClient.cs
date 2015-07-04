using System;
using System.Linq;
using System.Threading;

using Draft.Configuration;
using Draft.Endpoints;
using Draft.Requests;
using Draft.Requests.Cluster;
using Draft.Requests.Statistics;

namespace Draft
{
    internal class EtcdClient : IEtcdClient, IAtomicEtcdClient, IClusterEtcdClient, IStatisticsEtcdClient
    {

        private readonly object _gate = new object();

        private ClientConfig _clientConfig;

        public EtcdClient(EndpointPool endpointPool, ClientConfig clientConfig)
        {
            EndpointPool = endpointPool;
            _clientConfig = clientConfig ?? new ClientConfig();
        }

        public IMutableEtcdClientConfig Config
        {
            get { return _clientConfig; }
        }

        IEtcdClientConfig IEtcdClient.Config
        {
            get { return Config; }
        }

        public EndpointPool EndpointPool { get; private set; }

        #region Client Config

        public void Configure(Action<IMutableEtcdClientConfig> configAction)
        {
            var clientConfig = _clientConfig.DeepCopy();
            lock (_gate)
            {
                configAction(clientConfig);
                Interlocked.Exchange(ref _clientConfig, clientConfig);
            }
        }

        #endregion

        #region IEtcd Client

        public ICreateDirectoryRequest CreateDirectory(string key)
        {
            return new UpsertQueueRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key)
            {
                IsDirectory = true
            };
        }

        public IDeleteDirectoryRequest DeleteDirectory(string key)
        {
            return new DeleteRequest(this, EndpointPool, true, Constants.Etcd.Path_Keys, key);
        }

        public IDeleteKeyRequest DeleteKey(string key)
        {
            return new DeleteRequest(this, EndpointPool, false, Constants.Etcd.Path_Keys, key);
        }

        public IGetRequest GetKey(string key)
        {
            return new GetRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key);
        }

        public IGetVersionRequest GetVersion()
        {
            return new GetVersionRequest(this, EndpointPool, Constants.Etcd.Path_Version);
        }

        public IUpdateDirectoryRequest UpdateDirectory(string key)
        {
            var request = new UpsertQueueRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key)
            {
                IsDirectory = true
            };

            request.WithExisting();

            return request;
        }

        public IUpsertKeyRequest UpsertKey(string key)
        {
            return new UpsertQueueRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key);
        }

        public IWatchRequest Watch(string key)
        {
            return new WatchRequest(this, EndpointPool, false, Constants.Etcd.Path_Keys, key);
        }

        public IWatchRequest WatchOnce(string key)
        {
            return new WatchRequest(this, EndpointPool, true, Constants.Etcd.Path_Keys, key);
        }

        #endregion

        #region IAtomicEtcd Client

        public IAtomicEtcdClient Atomic
        {
            get { return this; }
        }

        public ICompareAndDeleteRequest CompareAndDelete(string key)
        {
            return new CompareAndDeleteRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key);
        }

        public ICompareAndSwapRequest CompareAndSwap(string key)
        {
            return new CompareAndSwapRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key);
        }

        public IQueueRequest Enqueue(string key)
        {
            return new UpsertQueueRequest(this, EndpointPool, Constants.Etcd.Path_Keys, key)
            {
                IsQueue = true
            };
        }

        #endregion

        #region IClusterEtcd Client

        public IClusterEtcdClient Cluster
        {
            get { return this; }
        }

        public ICreateMemberRequest CreateMember()
        {
            return new CreateMemberRequest(this, EndpointPool, Constants.Etcd.Path_Members);
        }

        public IDeleteMemberRequest DeleteMember()
        {
            return new DeleteMemberRequest(this, EndpointPool, Constants.Etcd.Path_Members);
        }

        public IGetLeaderRequest GetLeader()
        {
            return new GetLeaderRequest(this, EndpointPool, Constants.Etcd.Path_Members_Leader);
        }

        public IGetMembersRequest GetMembers()
        {
            return new GetMembersRequest(this, EndpointPool, Constants.Etcd.Path_Members);
        }

        public IUpdateMemberPeerUrlsRequest UpdateMemberPeerUrls()
        {
            return new UpdateMemberPeerUrlsRequest(this, EndpointPool, Constants.Etcd.Path_Members);
        }

        #endregion

        #region IStatisticsEtcd Client

        public IStatisticsEtcdClient Statistics
        {
            get { return this; }
        }

        public IGetLeaderStatisticsRequest GetLeaderStatistics()
        {
            return new GetLeaderStatisticsRequest(this, EndpointPool, Constants.Etcd.Path_Stats_Leader);
        }

        public IGetServerStatisticsRequest GetServerStatistics()
        {
            return new GetSelfStatisticsRequest(this, EndpointPool, Constants.Etcd.Path_Stats_Self);
        }

        public IGetStoreStatisticsRequest GetStoreStatistics()
        {
            return new GetStoreStatisticsRequest(this, EndpointPool, Constants.Etcd.Path_Stats_Store);
        }

        #endregion
    }
}
