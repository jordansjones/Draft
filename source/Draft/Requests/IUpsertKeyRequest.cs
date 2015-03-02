using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to insert or update a key.
    /// </summary>
    public interface IUpsertKeyRequest
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
        ///     <para>When <c>true</c>, this request will be treated as an update and will only succeed if the key already exists.</para>
        ///     <para>
        ///         When <c>false</c>, this request will be treated as an insert and will only succeed if they key doesn't
        ///         already exist.
        ///     </para>
        /// </summary>
        IUpsertKeyRequest WithExisting(bool existing = true);

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        IUpsertKeyRequest WithTimeToLive(long? seconds = 0);

        /// <summary>
        ///     The value to set for this key's node.
        /// </summary>
        IUpsertKeyRequest WithValue(string value);

    }
}
