using System;
using System.Linq;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Etcd endpoint availability indicators
    /// </summary>
    public enum EndpointAvailability
    {

        /// <summary>
        ///     Endpoint availability is not known.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Endpoint is known to be correct and online.
        /// </summary>
        Online,

        /// <summary>
        ///     Endpoint is known to be incorrect or offline.
        /// </summary>
        Offline


    }
}
