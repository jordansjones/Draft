using System;
using System.Linq;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Represents a strategy for selecting which etcd endpoint to use for http calls.
    /// </summary>
    public abstract class EndpointRoutingStrategy
    {

        internal static EndpointRoutingStrategy Default
        {
            get { return First; }
        }

        /// <summary>
        ///     Executes the strategy against the passed <paramref name="key" /> and <paramref name="endpoints" />.
        /// </summary>
        /// <param name="key">The etcd key for the current http call.</param>
        /// <param name="endpoints">The <see cref="EndpointAvailability.Online" /> etcd endpoints.</param>
        /// <returns>The <see cref="Endpoint" /> to use in the current http call.</returns>
        public abstract Endpoint Select(string key, Endpoint[] endpoints);

        #region Built-in strategies

        private static readonly Lazy<EndpointRoutingStrategy> LazyConsistenKeyHashing = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyConsistentKeyHashing());

        private static readonly Lazy<EndpointRoutingStrategy> LazyFirst = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyFirst());

        private static readonly Lazy<EndpointRoutingStrategy> LazyRandom = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyRandom());

        private static readonly Lazy<EndpointRoutingStrategy> LazyRoundRobin = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyRoundRobin());

//        /// <summary>
//        ///     Uses a consistent hashing algorithm on the etcd key to select the <see cref="Endpoint" />.
//        /// </summary>
//        public static EndpointRoutingStrategy ConsistentKeyHashing
//        {
//            get { return LazyConsistenKeyHashing.Value; }
//        }

        /// <summary>
        ///     Uses the first <see cref="Endpoint" />.
        /// </summary>
        public static EndpointRoutingStrategy First
        {
            get { return LazyFirst.Value; }
        }

        /// <summary>
        ///     Uses a randomly selected <see cref="Endpoint" />.
        /// </summary>
        public static EndpointRoutingStrategy Random
        {
            get { return LazyRandom.Value; }
        }

        /// <summary>
        ///     Uses a round-robin patter for selecting the <see cref="Endpoint" />.
        /// </summary>
        public static EndpointRoutingStrategy RoundRobin
        {
            get { return LazyRoundRobin.Value; }
        }

        #endregion
    }
}
