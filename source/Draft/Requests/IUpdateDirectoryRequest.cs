using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to update a directory.
    /// </summary>
    /// <remarks>
    ///     <para>Primarily used for updating the TTL.</para>
    /// </remarks>
    public interface IUpdateDirectoryRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

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
        IUpdateDirectoryRequest WithTimeToLive(long? seconds = 0);

    }
}
