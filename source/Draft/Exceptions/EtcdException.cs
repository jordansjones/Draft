using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;

using Draft.Responses;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Base exception that is thrown when etcd returns an error response.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class EtcdException : Exception
    {

        /// <summary>
        ///     Initializes a new <see cref="EtcdException" /> instance.
        /// </summary>
        protected EtcdException() {}

        /// <summary>
        ///     Initializes a new <see cref="EtcdException" /> instance with a specified error message.
        /// </summary>
        protected EtcdException(string message) : base(message) {}

        /// <summary>
        ///     The parsed etcd error message if available.
        /// </summary>
        public IEtcdError EtcdError { get; internal set; }

        /// <summary>
        ///     The <see cref="System.Net.HttpStatusCode" /> if the operation returned a response.
        /// </summary>
        public HttpStatusCode? HttpStatusCode { get; internal set; }

        /// <summary>
        ///     Indicates that this exception is due to an internal client error
        /// </summary>
        public virtual bool IsClientInternal
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the passed directory still containing children.
        /// </summary>
        public virtual bool IsDirectoryNotEmpty
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the event in the requested index is outdated and cleared.
        /// </summary>
        public virtual bool IsEventIndexCleared
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to there being an existing peer address that matches the value passed.
        /// </summary>
        public virtual bool IsExistingPeerAddress
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to etcd being unable to parse the passed index value as a number.
        /// </summary>
        public virtual bool IsIndexNotANumber
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the request missing the index or value property.
        /// </summary>
        public virtual bool IsIndexOrValueRequired
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to "Index and value cannot both be specified."
        /// </summary>
        public virtual bool IsIndexValueMutex
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an "Invalid active size" error.
        /// </summary>
        public virtual bool IsInvalidActiveSize
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an invalid field value.
        /// </summary>
        public virtual bool IsInvalidField
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an invalid form post.
        /// </summary>
        public virtual bool IsInvalidForm
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to attempting to connect to a non-etcd endpoint.
        /// </summary>
        public virtual bool IsInvalidHost
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to a "Standby remove delay" error.
        /// </summary>
        public virtual bool IsInvalidRemoveDelay
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to attempting to use an etcd reserved keyword as a key operation key.
        /// </summary>
        public virtual bool IsKeyIsPreserved
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the passed keyspace key not existing.
        /// </summary>
        public virtual bool IsKeyNotFound
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an in process leader election.
        /// </summary>
        public virtual bool IsLeaderElect
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the name field is missing in the form post.
        /// </summary>
        public virtual bool IsNameRequired
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the passed key already existing.
        /// </summary>
        public virtual bool IsNodeExists
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to reaching the max number of peers in the cluster.
        /// </summary>
        public virtual bool IsNoMorePeer
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to attempting a directory based operation on a key that isn't a directory.
        /// </summary>
        public virtual bool IsNotDirectory
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to attempting a file based operation on a key that isn't a file.
        /// </summary>
        public virtual bool IsNotFile
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the previous value field missing in the form post.
        /// </summary>
        public virtual bool IsPreviousValueRequired
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an internal raft error.
        /// </summary>
        public virtual bool IsRaftInternal
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the root keyspace being read only.
        /// </summary>
        /// <remarks>You probably tried to set a value on the root keyspace.</remarks>
        public virtual bool IsRootReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an "Internal standby error".
        /// </summary>
        public virtual bool IsStandbyInternal
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the compare test failing.
        /// </summary>
        public virtual bool IsTestFailed
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an HTTP timeout error.
        /// </summary>
        public virtual bool IsTimeout
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the etcd being unable to parse the passed timeout value as a number.
        /// </summary>
        public virtual bool IsTimeoutNotANumber
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to etcd being unable to parse the passed ttl value as a number.
        /// </summary>
        public virtual bool IsTtlNotANumber
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to an unknown error.
        /// </summary>
        public virtual bool IsUnknown
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the value or ttl field missing in the form post.
        /// </summary>
        public virtual bool IsValueOrTtlRequired
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the value field missing in the form post.
        /// </summary>
        public virtual bool IsValueRequired
        {
            get { return false; }
        }

        /// <summary>
        ///     Indicates that this exception is due to the watcher being cleared as a result of etcd recovery.
        /// </summary>
        public virtual bool IsWatcherCleared
        {
            get { return false; }
        }

        /// <summary>
        ///     The request method for the operation.
        /// </summary>
        public HttpMethod RequestMethod { get; internal set; }

        /// <summary>
        ///     The request url for the operation.
        /// </summary>
        public string RequestUrl { get; internal set; }


    }
}
