using System;
using System.Linq;

namespace Draft
{
    internal static class HeaderConstants
    {

        public const string ClusterId = "X-Etcd-Cluster-Id";

        public const string EtcdIndex = "X-Etcd-Index";

        public const string RaftIndex = "X-Raft-Index";

        public const string RaftTerm = "X-Raft-Term";

    }
}
