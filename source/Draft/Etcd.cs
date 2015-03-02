using System;
using System.Linq;

using Flurl;

namespace Draft
{
    /// <summary>
    ///     Factory class for configuring and creating <see cref="IEtcdClient" />s.
    /// </summary>
    public static class Etcd
    {

        /// <summary>
        ///     Creates an <see cref="IEtcdClient" /> for the specified <see cref="Uri" />.
        /// </summary>
        /// <exception cref="ArgumentException">The <see cref="Uri" /> is not an absolute uri.</exception>
        public static IEtcdClient ClientFor(Uri uri)
        {
            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException("Uri must be absolute", "uri");
            }

            return new EtcdClient(new Url(uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)));
        }

    }
}
