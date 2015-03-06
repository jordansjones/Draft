using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     Base interface for all Etcd Responses
    /// </summary>
    public interface IEtcdResponse
    {

        /// <summary>
        ///     Etcd includes a few HTTP headers in responses that provide global information about the etcd cluster that serviced
        ///     a request.
        /// </summary>
        IResponseHeaders GetResponseHeaders();

    }
}
