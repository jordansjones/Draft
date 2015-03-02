using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to atomically create an in-order key.
    /// </summary>
    public interface IQueueRequest
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
        ///     An optional expiration for this key.
        /// </summary>
        IQueueRequest WithTimeToLive(long? seconds = 0);

        /// <summary>
        ///     The value to set for this key's node.
        /// </summary>
        IQueueRequest WithValue(string value);

    }
}
