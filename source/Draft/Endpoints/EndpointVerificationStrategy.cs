using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Draft.Exceptions;

namespace Draft.Endpoints
{
    /// <summary>
    ///     Represents a strategy for verifying etcd enpoint availability.
    /// </summary>
    [Serializable, DataContract]
    public abstract class EndpointVerificationStrategy
    {

        [IgnoreDataMember]
        internal static EndpointVerificationStrategy Default
        {
            get { return None; }
        }

        /// <summary>
        ///     Executes the strategy against the passed <see cref="IEnumerable{Uri}" /> endpoints.
        /// </summary>
        /// <param name="endpointUris"><see cref="IEnumerable{Uri}" /> endpoints to verify</param>
        /// <exception cref="InvalidHostException">May be thrown depending on the underlying strategy implementation.</exception>
        public abstract Task<IEnumerable<Endpoint>> Verify(IEnumerable<Uri> endpointUris);

        #region Built-in strategies

        [IgnoreDataMember]
        private static readonly Lazy<EndpointVerificationStrategy> LazyAll = new Lazy<EndpointVerificationStrategy>(() => new VerificationStrategyAll());

        [IgnoreDataMember]
        private static readonly Lazy<EndpointVerificationStrategy> LazyAny = new Lazy<EndpointVerificationStrategy>(() => new VerificationStrategyAny());

        [IgnoreDataMember]
        private static readonly Lazy<EndpointVerificationStrategy> LazyClusterMembers = new Lazy<EndpointVerificationStrategy>(() => new VerificationStrategyClusterMembers());

        [IgnoreDataMember]
        private static readonly Lazy<EndpointVerificationStrategy> LazyNone = new Lazy<EndpointVerificationStrategy>(() => new VerificationStrategyNone());

        /// <summary>
        ///     Verify all supplied endpoints are responding.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointVerificationStrategy All
        {
            get { return LazyAll.Value; }
        }

        /// <summary>
        ///     Verify any supplied endpoints are responding.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointVerificationStrategy Any
        {
            get { return LazyAny.Value; }
        }

        /// <summary>
        ///     Similar verification as <see cref="Any" /> but also adds verified cluster members to the <see cref="EndpointPool" />.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointVerificationStrategy ClusterMembers
        {
            get { return LazyClusterMembers.Value; }
        }

        /// <summary>
        ///     Doesn't do any endpoint verification.
        /// </summary>
        [IgnoreDataMember]
        public static EndpointVerificationStrategy None
        {
            get { return LazyNone.Value; }
        }

        #endregion
    }
}
