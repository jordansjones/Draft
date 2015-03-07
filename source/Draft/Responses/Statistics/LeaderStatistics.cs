using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    /// Statistics about communication with cluster members
    /// </summary>
    [DataContract]
    internal class LeaderStatistics
    {
        /// <summary>
        /// Id for the currently elected cluster leader
        /// </summary>
        [DataMember(Name = "leader")]
        public string Leader { get; private set; }
        
        /// <summary>
        /// Map of cluster member id's to cluster member statistics
        /// </summary>
        [DataMember(Name = "followers")]
        public IReadOnlyDictionary<string, FollowerStatistics> Followers { get; private set; }
    }
}