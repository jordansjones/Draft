using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     State information for a key's node.
    /// </summary>
    public interface IKeyData
    {

        /// <summary>
        ///     When <see cref="IsDir" /> is <code>true</code>, this will contain this key's directory contents.
        /// </summary>
        IKeyData[] Children { get; }

        /// <summary>
        ///     The etcd index at which this key's node was created.
        /// </summary>
        long CreatedIndex { get; }

        /// <summary>
        ///     The time at which this key's node will expire and be deleted.
        /// </summary>
        /// <remarks>
        ///     <para>Will be <c>null</c> if no <c>Time To Live</c> value was provided on the create/update request for this key.</para>
        /// </remarks>
        DateTime? Expiration { get; }

        /// <summary>
        ///     Indicates whether this key's node is an Etcd directory.
        /// </summary>
        bool IsDir { get; }

        /// <summary>
        ///     The path to this key's node.
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     The Etcd index at which this key's node was modified.
        /// </summary>
        long? ModifiedIndex { get; }

        /// <summary>
        ///     The time to live for this key's node in seconds.
        /// </summary>
        /// <remarks>
        ///     <para>Will be <c>null</c> if no <c>Time To Live</c> value was provided on the create/update request for this key.</para>
        /// </remarks>
        long? TtlSeconds { get; }

        /// <summary>
        ///     The raw value of this key's node.
        /// </summary>
        string Value { get; }

    }
}
