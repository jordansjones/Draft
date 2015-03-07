using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to atomically update a key.
    /// </summary>
    public interface ICompareAndSwapRequest
    {

        /// <summary>
        ///     Attempt to update a key with the expected modified index.
        /// </summary>
        /// <param name="modifiedIndex">The expected modified index.</param>
        ICompareAndSwapByIndexRequest WithExpectedIndex(long modifiedIndex);

        /// <summary>
        ///     Attempt to update a key with the expected value.
        /// </summary>
        /// <param name="value">The expected value.</param>
        ICompareAndSwapByValueRequest WithExpectedValue(string value);

    }

    /// <summary>
    ///     A request to atomically update a key with an expected modified index.
    /// </summary>
    public interface ICompareAndSwapByIndexRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IKeyEvent> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IKeyEvent> GetAwaiter();

        /// <summary>
        ///     The new value for this key's node.
        /// </summary>
        ICompareAndSwapByIndexRequest WithNewValue(string value);

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        ICompareAndSwapByIndexRequest WithTimeToLive(long? seconds = 0);

    }

    /// <summary>
    ///     A request to atomically update a key with an expected value.
    /// </summary>
    public interface ICompareAndSwapByValueRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IKeyEvent> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IKeyEvent> GetAwaiter();

        /// <summary>
        ///     The new value for this key.
        /// </summary>
        ICompareAndSwapByValueRequest WithNewValue(string value);

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        ICompareAndSwapByValueRequest WithTimeToLive(long? seconds = 0);

    }
}
