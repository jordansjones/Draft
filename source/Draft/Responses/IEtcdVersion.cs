using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     Etcd response for the Version operation
    /// </summary>
    public interface IEtcdVersion
    {

        /// <summary>
        ///     Internal version number
        /// </summary>
        string Internal { get; }

        /// <summary>
        ///     Release Version Number
        /// </summary>
        string Release { get; }

    }
}
