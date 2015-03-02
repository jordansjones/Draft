using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to atomically delete a key.
    /// </summary>
    public interface ICompareAndDeleteRequest
    {

        /// <summary>
        ///     Attempt to delete a key with the expected modified index.
        /// </summary>
        /// <param name="modifiedIndex">The expected modified index.</param>
        ICompareAndDeleteByIndexRequest WithExpectedIndex(long modifiedIndex);

        /// <summary>
        ///     Attempt to delete a key with the expected value.
        /// </summary>
        /// <param name="value">The expected value.</param>
        ICompareAndDeleteByValueRequest WithExpectedValue(string value);

    }

    /// <summary>
    ///     A request to atomically delete a key with an expected modified index.
    /// </summary>
    public interface ICompareAndDeleteByIndexRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IKeyEvent> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IKeyEvent> GetAwaiter();

    }

    /// <summary>
    ///     A request to atomically delete a key with an expected value.
    /// </summary>
    public interface ICompareAndDeleteByValueRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IKeyEvent> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IKeyEvent> GetAwaiter();

    }
}
