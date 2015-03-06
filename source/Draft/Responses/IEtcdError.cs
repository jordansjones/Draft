using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     An etcd error response message.
    /// </summary>
    public interface IEtcdError
    {

        /// <summary>
        ///     The cause of the error.
        /// </summary>
        string Cause { get; }

        /// <summary>
        ///     The etcd error code.
        /// </summary>
        EtcdErrorCode? ErrorCode { get; }

        /// <summary>
        ///     The current etcd index if applicable.
        /// </summary>
        long? Index { get; }

        /// <summary>
        ///     The message.
        /// </summary>
        string Message { get; }

    }
}
