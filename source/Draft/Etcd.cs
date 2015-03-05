using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

using Draft.Configuration;

using Flurl;
using Flurl.Http;

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

        static Etcd()
        {
            FlurlHttp.Configure(
                c =>
                {
                    c.BeforeCall = http =>
                    {
                        //if (http.Request.Method != HttpMethod.Post && http.Request.Method != HttpMethod.Put) return;

                        if (http.Request.Content == null) return;

                        if (http.Request.Content.Headers.ContentType.MediaType == "application/json")
                        {
                            http.Request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                        }
                    };
                });
        }

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
