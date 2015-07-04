using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistics about communication with cluster members
    /// </summary>
    [DataContract]
    internal class LeaderStatistics : ILeaderStatistics
    {

        [DataMember(Name = "followers")]
        private Dictionary<string, FollowerStatistics> _followers;

        /// <summary>
        ///     Map of cluster member id's to cluster member statistics
        /// </summary>
        [IgnoreDataMember]
        public Dictionary<string, FollowerStatistics> Followers
        {
            get { return _followers ?? (_followers = new Dictionary<string, FollowerStatistics>()); }
        }

        [IgnoreDataMember]
        IReadOnlyDictionary<string, IFollowerStatistics> ILeaderStatistics.Followers
        {
            get { return Followers.ToDictionary(x => x.Key, x => x.Value as IFollowerStatistics); }
        }

        /// <summary>
        ///     Id for the currently elected cluster leader
        /// </summary>
        [DataMember(Name = "leader")]
        public string Leader { get; set; }

    }

}
