using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to retrieve a key's node.
    /// </summary>
    public interface IGetRequest
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
        ///     When <c>true</c>, this will enable a fully linearized read.
        /// </summary>
        IGetRequest WithQuorum(bool quorum = true);

        /// <summary>
        ///     When <c>true</c>, this request will also return all children of this key's node.
        /// </summary>
        IGetRequest WithRecursive(bool recursive = true);

        /// <summary>
        ///    Override the default timeout for this request. 
        /// </summary>
        IGetRequest WithTimeout(TimeSpan timeout);

    }
}
