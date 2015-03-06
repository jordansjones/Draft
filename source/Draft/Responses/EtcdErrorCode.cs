using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Draft.Responses
{
    /// <summary>
    ///     Etcd error codes
    /// </summary>
    public enum EtcdErrorCode
    {

        /// <summary>
        ///     Unable to determine errorcode from response
        /// </summary>
        Unknown,

        #region Command related

        /// <summary>
        ///     Key not found
        /// </summary>
        KeyNotFound,

        /// <summary>
        ///     Compare failed
        /// </summary>
        TestFailed,

        /// <summary>
        ///     Not a file
        /// </summary>
        NotFile,

        /// <summary>
        ///     Reached the max number of peers in the cluster
        /// </summary>
        NoMorePeer,

        /// <summary>
        ///     Not a directory
        /// </summary>
        NotDirectory,

        /// <summary>
        ///     Key already exists
        /// </summary>
        NodeExists,

        /// <summary>
        ///     The prefix of given key is a keyword in etcd
        /// </summary>
        KeyIsPreserved,

        /// <summary>
        ///     Root is read only
        /// </summary>
        RootReadOnly,

        /// <summary>
        ///     Directory not empty
        /// </summary>
        DirectoryNotEmpty,

        /// <summary>
        ///     Peer address has "existed"
        /// </summary>
        ExistingPeerAddress,

        #endregion

        #region Post form related

        /// <summary>
        ///     Value is required in POST form
        /// </summary>
        ValueRequired,

        /// <summary>
        ///     PrevValue is required in POST form
        /// </summary>
        PreviousValueRequired,

        /// <summary>
        ///     The given TTL in POST form is not a number
        /// </summary>
        TtlNotANumber,

        /// <summary>
        ///     The given index in POST form is not a number
        /// </summary>
        IndexNotANumber,

        /// <summary>
        ///     Value or TTL is required in POST form
        /// </summary>
        ValueOrTtlRequired,

        /// <summary>
        ///     The given timeout in POST form is not a number
        /// </summary>
        TimeoutNotANumber,

        /// <summary>
        ///     Name is required in POST form
        /// </summary>
        NameRequired,

        /// <summary>
        ///     Index or value is required
        /// </summary>
        IndexOrValueRequired,

        /// <summary>
        ///     Index and value cannot both be specified
        /// </summary>
        IndexValueMutex,

        /// <summary>
        ///     Field is not valid
        /// </summary>
        InvalidField,

        /// <summary>
        ///     Invalid POST form
        /// </summary>
        InvalidForm,

        #endregion

        #region Raft related

        /// <summary>
        ///     Internal RAFT error
        /// </summary>
        RaftInternal,

        /// <summary>
        ///     During leader election
        /// </summary>
        LeaderElect,

        #endregion

        #region Etcd related

        /// <summary>
        ///     Watcher is cleared due to etcd recovery
        /// </summary>
        WatcherCleared,

        /// <summary>
        ///     The event in requested index is outdated and cleared
        /// </summary>
        EventIndexCleared,

        /// <summary>
        ///     Standby Internal Error
        /// </summary>
        StandbyInternal,

        /// <summary>
        ///     Invalid active size
        /// </summary>
        InvalidActiveSize,

        /// <summary>
        ///     Standby remove delay
        /// </summary>
        InvalidRemoveDelay,

        #endregion

        /// <summary>
        ///     Client internal error
        /// </summary>
        ClientInternal

    }

    internal static class EtcdErrorCodeMapping
    {

        private static readonly Dictionary<int, EtcdErrorCode> Mapping = new Dictionary<int, EtcdErrorCode>(Enum.GetValues(typeof (EtcdErrorCode)).Length)
        {
            // Command related
            {Constants.Etcd.ErrorCode_KeyNotFound, EtcdErrorCode.KeyNotFound},
            {Constants.Etcd.ErrorCode_TestFailed, EtcdErrorCode.TestFailed},
            {Constants.Etcd.ErrorCode_NotFile, EtcdErrorCode.NotFile},
            {Constants.Etcd.ErrorCode_NoMorePeer, EtcdErrorCode.NoMorePeer},
            {Constants.Etcd.ErrorCode_NotDirectory, EtcdErrorCode.NotDirectory},
            {Constants.Etcd.ErrorCode_NodeExists, EtcdErrorCode.NodeExists},
            {Constants.Etcd.ErrorCode_KeyIsPreserved, EtcdErrorCode.KeyIsPreserved},
            {Constants.Etcd.ErrorCode_RootReadOnly, EtcdErrorCode.RootReadOnly},
            {Constants.Etcd.ErrorCode_DirectoryNotEmpty, EtcdErrorCode.DirectoryNotEmpty},
            {Constants.Etcd.ErrorCode_ExistingPeerAddress, EtcdErrorCode.ExistingPeerAddress},

            // Post form related
            {Constants.Etcd.ErrorCode_ValueRequired, EtcdErrorCode.ValueRequired},
            {Constants.Etcd.ErrorCode_PreviousValueRequired, EtcdErrorCode.PreviousValueRequired},
            {Constants.Etcd.ErrorCode_TtlNotANumber, EtcdErrorCode.TtlNotANumber},
            {Constants.Etcd.ErrorCode_IndexNotANumber, EtcdErrorCode.IndexNotANumber},
            {Constants.Etcd.ErrorCode_ValueOrTtlRequired, EtcdErrorCode.ValueOrTtlRequired},
            {Constants.Etcd.ErrorCode_TimeoutNotANumber, EtcdErrorCode.TimeoutNotANumber},
            {Constants.Etcd.ErrorCode_NameRequired, EtcdErrorCode.NameRequired},
            {Constants.Etcd.ErrorCode_IndexOrValueRequired, EtcdErrorCode.IndexOrValueRequired},
            {Constants.Etcd.ErrorCode_IndexValueMutex, EtcdErrorCode.IndexValueMutex},
            {Constants.Etcd.ErrorCode_InvalidField, EtcdErrorCode.InvalidField},
            {Constants.Etcd.ErrorCode_InvalidForm, EtcdErrorCode.InvalidForm},

            // Raft related
            {Constants.Etcd.ErrorCode_RaftInternal, EtcdErrorCode.RaftInternal},
            {Constants.Etcd.ErrorCode_LeaderElect, EtcdErrorCode.LeaderElect},

            // Etcd related
            {Constants.Etcd.ErrorCode_WatcherCleared, EtcdErrorCode.WatcherCleared},
            {Constants.Etcd.ErrorCode_EventIndexCleared, EtcdErrorCode.EventIndexCleared},
            {Constants.Etcd.ErrorCode_StandbyInternal, EtcdErrorCode.StandbyInternal},
            {Constants.Etcd.ErrorCode_InvalidActiveSize, EtcdErrorCode.InvalidActiveSize},
            {Constants.Etcd.ErrorCode_InvalidRemoveDelay, EtcdErrorCode.InvalidRemoveDelay},

            // Other
            {Constants.Etcd.ErrorCode_ClientInternal, EtcdErrorCode.ClientInternal},
            {Constants.Etcd.ErrorCode_Unknown, EtcdErrorCode.Unknown}
        };


        public static EtcdErrorCode? Map(this HttpStatusCode This)
        {
            var code = (int) This;

            if (This == HttpStatusCode.Conflict)
            {
                code = Constants.Etcd.ErrorCode_ExistingPeerAddress;
            }

            return code.Map();
        }

        public static EtcdErrorCode? Map(this int? This)
        {
            return This.HasValue
                ? This.Value.Map()
                : null;
        }

        public static EtcdErrorCode? Map(this int This)
        {
            EtcdErrorCode result;
            if (Mapping.TryGetValue(This, out result)) { return result; }

            return null;
        }

        public static int? RawValue(this EtcdErrorCode? This)
        {
            return This.HasValue
                ? This.Value.RawValue()
                : null;
        }

        public static int? RawValue(this EtcdErrorCode This)
        {
            return Mapping
                .Where(x => x.Value == This)
                .Select(x => x.Key)
                .FirstOrDefault();
        }

    }

}
