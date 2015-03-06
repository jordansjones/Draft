using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Draft
{

    internal static partial class Constants
    {

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        internal static partial class Etcd
        {
            #region Command related

            public const int ErrorCode_KeyNotFound = 100;

            public const int ErrorCode_TestFailed = 101;

            public const int ErrorCode_NotFile = 102;

            public const int ErrorCode_NoMorePeer = 103;

            public const int ErrorCode_NotDirectory = 104;

            public const int ErrorCode_NodeExists = 105;

            public const int ErrorCode_KeyIsPreserved = 106;

            public const int ErrorCode_RootReadOnly = 107;

            public const int ErrorCode_DirectoryNotEmpty = 108;

            public const int ErrorCode_ExistingPeerAddress = 109;

            #endregion

            #region Post form related

            public const int ErrorCode_ValueRequired = 200;

            public const int ErrorCode_PreviousValueRequired = 201;

            public const int ErrorCode_TtlNotANumber = 202;

            public const int ErrorCode_IndexNotANumber = 203;

            public const int ErrorCode_ValueOrTtlRequired = 204;

            public const int ErrorCode_TimeoutNotANumber = 205;

            public const int ErrorCode_NameRequired = 206;

            public const int ErrorCode_IndexOrValueRequired = 207;

            public const int ErrorCode_IndexValueMutex = 208;

            public const int ErrorCode_InvalidField = 209;

            public const int ErrorCode_InvalidForm = 210;

            #endregion

            #region Raft related

            public const int ErrorCode_RaftInternal = 300;

            public const int ErrorCode_LeaderElect = 301;

            #endregion

            #region Etcd related

            public const int ErrorCode_WatcherCleared = 400;

            public const int ErrorCode_EventIndexCleared = 401;

            public const int ErrorCode_StandbyInternal = 402;

            public const int ErrorCode_InvalidActiveSize = 403;

            public const int ErrorCode_InvalidRemoveDelay = 404;

            #endregion

            #region Other

            public const int ErrorCode_ClientInternal = 500;

            public const int ErrorCode_Unknown = int.MinValue;

            #endregion
        }

    }

}
