using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Etcd backing store statistics
    /// </summary>
    public interface IStoreStatistics
    {

        /// <summary>
        ///     Number of failed Compare and Delete requests
        /// </summary>
        long CompareAndDeleteFail { get; }

        /// <summary>
        ///     Number of successful Compare and Delete requests
        /// </summary>
        long CompareAndDeleteSuccess { get; }

        /// <summary>
        ///     Number of failed Compare and Swap requests
        /// </summary>
        long CompareAndSwapFail { get; }

        /// <summary>
        ///     Number of successful Compare and Swap requests
        /// </summary>
        long CompareAndSwapSuccess { get; }

        /// <summary>
        ///     Number of failed Create requests
        /// </summary>
        long CreateFail { get; }

        /// <summary>
        ///     Number of successful Create requests
        /// </summary>
        long CreateSuccess { get; }

        /// <summary>
        ///     Number of failed Delete requests
        /// </summary>
        long DeleteFail { get; }

        /// <summary>
        ///     Number of successful Delete requests
        /// </summary>
        long DeleteSuccess { get; }

        /// <summary>
        ///     Number of key expirations
        /// </summary>
        long ExpireCount { get; }

        /// <summary>
        ///     Number of failed Get requests
        /// </summary>
        long GetsFail { get; }

        /// <summary>
        ///     Number of successful Get requests
        /// </summary>
        long GetsSuccess { get; }

        /// <summary>
        ///     Number of failed Set requests
        /// </summary>
        long SetsFail { get; }

        /// <summary>
        ///     Number of successful Set requests
        /// </summary>
        long SetsSuccess { get; }

        /// <summary>
        ///     Number of failed Update requests
        /// </summary>
        long UpdateFail { get; }

        /// <summary>
        ///     Number of successful Update requests
        /// </summary>
        long UpdateSuccess { get; }

        /// <summary>
        ///     Number of active watchers
        /// </summary>
        long Watchers { get; }

    }
}
