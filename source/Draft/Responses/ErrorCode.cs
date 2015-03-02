using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     Etcd error codes
    /// </summary>
    public enum ErrorCode
    {
        #region Command related

        /// <summary>
        ///     Key not found
        /// </summary>
        KeyNotFound = 100,

        /// <summary>
        ///     Compare failed
        /// </summary>
        TestFailed = 101,

        /// <summary>
        ///     Not a file
        /// </summary>
        NotFile = 102,

        /// <summary>
        ///     Reached the max number of peers in the cluster
        /// </summary>
        NoMorePeer = 103,

        /// <summary>
        ///     Not a directory
        /// </summary>
        NotDir = 104,

        /// <summary>
        ///     Key already exists
        /// </summary>
        NodeExist = 105,

        /// <summary>
        ///     The prefix of given key is a keyword in etcd
        /// </summary>
        KeyIsPreserved = 106,

        /// <summary>
        ///     Root is read only
        /// </summary>
        RootReadOnly = 107,

        /// <summary>
        ///     Directory not empty
        /// </summary>
        DirNotEmpty = 108,

        /// <summary>
        ///     Peer address has "existed"
        /// </summary>
        ExistingPeerAddress = 109,

        #endregion

        #region Post form related

        /// <summary>
        ///     Value is required in POST form
        /// </summary>
        ValueRequired = 200,

        /// <summary>
        ///     PrevValue is required in POST form
        /// </summary>
        PrevValueRequired = 201,

        /// <summary>
        ///     The given TTL in POST form is not a number
        /// </summary>
        TtlNotANumber = 202,

        /// <summary>
        ///     The given index in POST form is not a number
        /// </summary>
        IndexNotANumber = 203,

        /// <summary>
        ///     Value or TTL is required in POST form
        /// </summary>
        ValueOrTtlRequired = 204,

        /// <summary>
        ///     The given timeout in POST form is not a number
        /// </summary>
        TimeoutNotANumber = 205,

        /// <summary>
        ///     Name is required in POST form
        /// </summary>
        NameRequired = 206,

        /// <summary>
        ///     Index or value is required
        /// </summary>
        IndexOrValueRequired = 207,

        /// <summary>
        ///     Index and value cannot both be specified
        /// </summary>
        IndexValueMutex = 208,

        /// <summary>
        ///     Field is not valid
        /// </summary>
        InvalidField = 209,

        /// <summary>
        ///     Invalid POST form
        /// </summary>
        InvalidForm = 210,

        #endregion

        #region Raft related

        /// <summary>
        ///     Internal RAFT error
        /// </summary>
        RaftInternal = 300,

        /// <summary>
        ///     During leader election
        /// </summary>
        LeaderElect = 301,

        #endregion

        #region Etcd related

        /// <summary>
        ///     Watcher is cleared due to etcd recovery
        /// </summary>
        WatcherCleared = 400,

        /// <summary>
        ///     The event in requested index is outdated and cleared
        /// </summary>
        EventIndexCleared = 401,

        /// <summary>
        ///     Standby Internal Error
        /// </summary>
        StandbyInternal = 402,

        /// <summary>
        ///     Invalid active size
        /// </summary>
        InvalidActiveSize = 403,

        /// <summary>
        ///     Standby remove delay
        /// </summary>
        InvalidRemoveDelay = 404,

        #endregion

        /// <summary>
        ///     Client internal error
        /// </summary>
        ClientInternal = 500

    }
}
