using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    /// <summary>
    ///     Etcd error codes
    /// </summary>
    [DataContract]
    public enum EtcdErrorCode
    {

        /// <summary>
        ///     Unable to determine errorcode from response
        /// </summary>
        [IgnoreDataMember]
        Unknown = int.MinValue,

        #region Command related

        /// <summary>
        ///     Key not found
        /// </summary>
        [EnumMember(Value = "100")]
        KeyNotFound = 100,

        /// <summary>
        ///     Compare failed
        /// </summary>
        [EnumMember(Value = "101")]
        TestFailed = 101,

        /// <summary>
        ///     Not a file
        /// </summary>
        [EnumMember(Value = "102")]
        NotFile = 102,

        /// <summary>
        ///     Reached the max number of peers in the cluster
        /// </summary>
        [EnumMember(Value = "103")]
        NoMorePeer = 103,

        /// <summary>
        ///     Not a directory
        /// </summary>
        [EnumMember(Value = "104")]
        NotDirectory = 104,

        /// <summary>
        ///     Key already exists
        /// </summary>
        [EnumMember(Value = "105")]
        NodeExists = 105,

        /// <summary>
        ///     The prefix of given key is a keyword in etcd
        /// </summary>
        [EnumMember(Value = "106")]
        KeyIsPreserved = 106,

        /// <summary>
        ///     Root is read only
        /// </summary>
        [EnumMember(Value = "107")]
        RootReadOnly = 107,

        /// <summary>
        ///     Directory not empty
        /// </summary>
        [EnumMember(Value = "108")]
        DirectoryNotEmpty = 108,

        /// <summary>
        ///     Peer address has "existed"
        /// </summary>
        [EnumMember(Value = "109")]
        ExistingPeerAddress = 109,

        #endregion

        #region Post form related

        /// <summary>
        ///     Value is required in POST form
        /// </summary>
        [EnumMember(Value = "200")]
        ValueRequired = 200,

        /// <summary>
        ///     PrevValue is required in POST form
        /// </summary>
        [EnumMember(Value = "201")]
        PreviousValueRequired = 201,

        /// <summary>
        ///     The given TTL in POST form is not a number
        /// </summary>
        [EnumMember(Value = "202")]
        TtlNotANumber = 202,

        /// <summary>
        ///     The given index in POST form is not a number
        /// </summary>
        [EnumMember(Value = "203")]
        IndexNotANumber = 203,

        /// <summary>
        ///     Value or TTL is required in POST form
        /// </summary>
        [EnumMember(Value = "204")]
        ValueOrTtlRequired = 204,

        /// <summary>
        ///     The given timeout in POST form is not a number
        /// </summary>
        [EnumMember(Value = "205")]
        TimeoutNotANumber = 205,

        /// <summary>
        ///     Name is required in POST form
        /// </summary>
        [EnumMember(Value = "206")]
        NameRequired = 206,

        /// <summary>
        ///     Index or value is required
        /// </summary>
        [EnumMember(Value = "207")]
        IndexOrValueRequired = 207,

        /// <summary>
        ///     Index and value cannot both be specified
        /// </summary>
        [EnumMember(Value = "208")]
        IndexValueMutex = 208,

        /// <summary>
        ///     Field is not valid
        /// </summary>
        [EnumMember(Value = "209")]
        InvalidField = 209,

        /// <summary>
        ///     Invalid POST form
        /// </summary>
        [EnumMember(Value = "210")]
        InvalidForm = 210,

        #endregion

        #region Raft related

        /// <summary>
        ///     Internal RAFT error
        /// </summary>
        [EnumMember(Value = "300")]
        RaftInternal = 300,

        /// <summary>
        ///     During leader election
        /// </summary>
        [EnumMember(Value = "301")]
        LeaderElect = 301,

        #endregion

        #region Etcd related

        /// <summary>
        ///     Watcher is cleared due to etcd recovery
        /// </summary>
        [EnumMember(Value = "400")]
        WatcherCleared = 400,

        /// <summary>
        ///     The event in requested index is outdated and cleared
        /// </summary>
        [EnumMember(Value = "401")]
        EventIndexCleared = 401,

        /// <summary>
        ///     Standby Internal Error
        /// </summary>
        [EnumMember(Value = "402")]
        StandbyInternal = 402,

        /// <summary>
        ///     Invalid active size
        /// </summary>
        [EnumMember(Value = "403")]
        InvalidActiveSize = 403,

        /// <summary>
        ///     Standby remove delay
        /// </summary>
        [EnumMember(Value = "404")]
        InvalidRemoveDelay = 404,

        #endregion

        /// <summary>
        ///     Client internal error
        /// </summary>
        [EnumMember(Value = "500")]
        ClientInternal = 500

    }
}
