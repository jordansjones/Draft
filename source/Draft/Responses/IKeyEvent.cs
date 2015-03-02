using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    /// Etcd response object from a key based operation
    /// </summary>
    public interface IKeyEvent : IEtcdResponse
    {
        /// <summary>
        /// The action of the request that was just made.
        /// </summary>
        KeyEventType Action { get; }

        /// <summary>
        /// State of a key node for the request that was just made.
        /// </summary>
        IKeyData Data { get; }

        /// <summary>
        /// State of a key node before the request that was just made.
        /// </summary>
        /// <remarks>
        /// <para>This field will be <code>null</code> in the event that there was no previous state.</para>
        /// </remarks>
        IKeyData PreviousData { get; }

    }
}
