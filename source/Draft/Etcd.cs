using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Draft.Configuration;

using Flurl;

namespace Draft
{
    /// <summary>
    ///     Factory class for configuring and creating <see cref="IEtcdClient" />s.
    /// </summary>
    public static class Etcd
    {

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static readonly Lazy<IEtcdClientConfig> _configuration = new Lazy<IEtcdClientConfig>(() => new ClientConfig());

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static readonly object _gate = new object();

        /// <summary>
        ///     <see cref="IEtcdClient" />'s global configuration options.
        /// </summary>
        public static IEtcdClientConfig Configuration
        {
            get { return _configuration.Value; }
        }

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

        /// <summary>
        ///     Provides thread-safe access to <see cref="IEtcdClient" />'s global configuration options.
        /// </summary>
        /// <remarks>
        ///     <para>Should only be called once on application initialization.</para>
        /// </remarks>
        public static void Configure(Action<IEtcdClientConfig> configAction)
        {
            lock (_gate)
            {
                configAction(Configuration);
            }
        }

    }
}
