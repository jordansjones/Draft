using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Draft
{

    internal static partial class Constants
    {

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static class Etcd
        {

            public const string Parameter_Directory = "dir";

            public const string Parameter_False = "false";

            public const string Parameter_Name = "name";

            public const string Parameter_PeerURLs = "peerURLs";

            public const string Parameter_PrevExist = "prevExist";

            public const string Parameter_PrevIndex = "prevIndex";

            public const string Parameter_PrevValue = "prevValue";

            public const string Parameter_Quorum = "quorum";

            public const string Parameter_Recursive = "recursive";

            public const string Parameter_Sorted = "sorted";

            public const string Parameter_True = "true";

            public const string Parameter_Ttl = "ttl";

            public const string Parameter_Value = "value";

            public const string Parameter_Wait = "wait";

            public const string Parameter_WaitIndex = "waitIndex";

            public const string Path_Health = "/health";

            public const string Path_Keys = "/v2/keys";

            public const string Path_Members = "/v2/members";

            public const string Path_Members_Leader = Path_Members + "/leader";

            public const string Path_Stats = "/v2/stats";

            public const string Path_Version = "/version";

        }

    }

}
