using System;
using System.Linq;

namespace Draft
{
    internal static class HeaderConstants
    {

        /// <summary>
        ///     Appears to be the unique identifier for the cluster
        /// </summary>
        public const string ClusterId = "X-Etcd-Cluster-Id";

        /// <summary>
        ///     The current etcd index
        /// </summary>
        public const string EtcdIndex = "X-Etcd-Index";

        /// <summary>
        ///     Similar to the etcd index but is for the underlying raft protocol
        /// </summary>
        public const string RaftIndex = "X-Raft-Index";

        /// <summary>
        ///     Incrementing integer whenever an etcd master election happens
        /// </summary>
        /// <remarks>
        ///     If this number is increasing rapidly, election tuning may be needed
        /// </remarks>
        public const string RaftTerm = "X-Raft-Term";

    }
}
