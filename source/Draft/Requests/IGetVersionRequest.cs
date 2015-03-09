using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to get the version information of the etcd server.
    /// </summary>
    public interface IGetVersionRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IEtcdVersion> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IEtcdVersion> GetAwaiter();

    }
}
