using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Etcd backing store statistics
    /// </summary>
    [DataContract]
    public class StoreStatistics
    {

        /// <summary>
        ///     Number of failed Compare and Swap requests
        /// </summary>
        [DataMember(Name = "compareAndSwapFail")]
        public long CompareAndSwapFail { get; private set; }

        /// <summary>
        ///     Number of successful Compare and Swap requests
        /// </summary>
        [DataMember(Name = "compareAndSwapSuccess")]
        public long CompareAndSwapSuccess { get; private set; }

        /// <summary>
        ///     Number of failed Create requests
        /// </summary>
        [DataMember(Name = "createFail")]
        public long CreateFail { get; private set; }

        /// <summary>
        ///     Number of successful Create requests
        /// </summary>
        [DataMember(Name = "createSuccess")]
        public long CreateSuccess { get; private set; }

        /// <summary>
        ///     Number of failed Delete requests
        /// </summary>
        [DataMember(Name = "deleteFail")]
        public long DeleteFail { get; private set; }

        /// <summary>
        ///     Number of successful Delete requests
        /// </summary>
        [DataMember(Name = "deleteSuccess")]
        public long DeleteSuccess { get; private set; }

        /// <summary>
        ///     Number of key expirations
        /// </summary>
        [DataMember(Name = "expireCount")]
        public long ExpireCount { get; private set; }

        /// <summary>
        ///     Number of failed Get requests
        /// </summary>
        [DataMember(Name = "getsFail")]
        public long GetsFail { get; private set; }

        /// <summary>
        ///     Number of successful Get requests
        /// </summary>
        [DataMember(Name = "getsSuccess")]
        public long GetsSuccess { get; private set; }

        /// <summary>
        ///     Number of failed Set requests
        /// </summary>
        [DataMember(Name = "setsFail")]
        public long SetsFail { get; private set; }

        /// <summary>
        ///     Number of successful Set requests
        /// </summary>
        [DataMember(Name = "setsSuccess")]
        public long SetsSuccess { get; private set; }

        /// <summary>
        ///     Number of failed Update requests
        /// </summary>
        [DataMember(Name = "updateFail")]
        public long UpdateFail { get; private set; }

        /// <summary>
        ///     Number of successful Update requests
        /// </summary>
        [DataMember(Name = "updateSuccess")]
        public long UpdateSuccess { get; private set; }

        /// <summary>
        ///     Number of active watchers
        /// </summary>
        [DataMember(Name = "watchers")]
        public long Watchers { get; private set; }

    }
}
