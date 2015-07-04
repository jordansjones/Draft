using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Represents a strategy for selecting which etcd endpoint to use for http calls.
    /// </summary>
    [Serializable, DataContract]
    public abstract class EndpointRoutingStrategy
    {

        [IgnoreDataMember]
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

        [IgnoreDataMember]
        private static readonly Lazy<EndpointRoutingStrategy> LazyFirst = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyFirst());

        [IgnoreDataMember]
        private static readonly Lazy<EndpointRoutingStrategy> LazyRandom = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyRandom());

        [IgnoreDataMember]
        private static readonly Lazy<EndpointRoutingStrategy> LazyRoundRobin = new Lazy<EndpointRoutingStrategy>(() => new RoutingStrategyRoundRobin());

        /// <summary>
        ///     Uses the first <see cref="Endpoint" />.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointRoutingStrategy First
        {
            get { return LazyFirst.Value; }
        }

        /// <summary>
        ///     Uses a randomly selected <see cref="Endpoint" />.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointRoutingStrategy Random
        {
            get { return LazyRandom.Value; }
        }

        /// <summary>
        ///     Uses a round-robin patter for selecting the <see cref="Endpoint" />.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointRoutingStrategy RoundRobin
        {
            get { return LazyRoundRobin.Value; }
        }

        #endregion
    }
}
