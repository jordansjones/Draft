using System;
using System.Linq;
using System.Threading.Tasks;

using Draft.Exceptions;

namespace Draft.Endpoints
{
    public sealed partial class EndpointPool
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="EndpointPool.Builder" /> class.
        /// </summary>
        public static Builder Build()
        {
            return new Builder();
        }

        /// <summary>
        ///     Helper class used to build a pool of etcd endpoints
        /// </summary>
        public sealed class Builder
        {

            private EndpointRoutingStrategy _routingStrategy;

            private EndpointVerificationStrategy _verificationStrategy;

            internal EndpointRoutingStrategy RoutingStrategy
            {
                get { return _routingStrategy ?? EndpointRoutingStrategy.Default; }
            }

            internal EndpointVerificationStrategy VerificationStrategy
            {
                get { return _verificationStrategy ?? EndpointVerificationStrategy.Default; }
            }

            /// <summary>
            ///     Verifies the passed <paramref name="uris" /> first to ensure that they are <see cref="Uri.IsAbsoluteUri" />. Then
            ///     leverages the defined <see cref="EndpointVerificationStrategy" />. Finally creates an <see cref="EndpointPool" />
            ///     with
            ///     the defined <see cref="EndpointRoutingStrategy" />.
            /// </summary>
            /// <param name="uris">Etcd endpoint uris to use.</param>
            /// <exception cref="ArgumentNullException">Passed <paramref name="uris" /> is null or empty.</exception>
            /// <exception cref="ArgumentException">One or more <paramref name="uris" /> is not an absolute <see cref="Uri" />.</exception>
            /// <exception cref="InvalidHostException">
            ///     May be thrown depending on the chosen
            ///     <see cref="EndpointVerificationStrategy" />.
            /// </exception>
            public async Task<EndpointPool> VerifyAndBuild(params Uri[] uris)
            {
                if (uris == null || !uris.Any())
                {
                    throw new ArgumentNullException("uris", "You must supply at least 1 Uri");
                }
                var invalidUris = uris.Where(x => !x.IsAbsoluteUri).ToList();
                if (invalidUris.Any())
                {
                    throw new ArgumentException(
                        string.Format("The following Uri(s) are not valid absolute Uri(s): '{0}'", string.Join(", ", invalidUris)),
                        "uris"
                        );
                }
                var endpoints = await VerificationStrategy.Verify(uris);

                return new EndpointPool(endpoints, RoutingStrategy);
            }

            /// <summary>
            ///     Defines the type of endpoint routing to use. Defaults to <see cref="EndpointRoutingStrategy.First" />.
            /// </summary>
            /// <exception cref="ArgumentNullException"><paramref name="routingStrategy" /> is <c>null</c>.</exception>
            public Builder WithRoutingStrategy(EndpointRoutingStrategy routingStrategy)
            {
                if (routingStrategy == null)
                {
                    throw new ArgumentNullException("routingStrategy");
                }
                _routingStrategy = routingStrategy;
                return this;
            }

            /// <summary>
            ///     Defines the type of endpoint verification to use. Defaults to <see cref="EndpointVerificationStrategy.None" />.
            /// </summary>
            /// <exception cref="ArgumentNullException"><paramref name="verificationStrategy" /> is <c>null</c>.</exception>
            public Builder WithVerificationStrategy(EndpointVerificationStrategy verificationStrategy)
            {
                if (verificationStrategy == null)
                {
                    throw new ArgumentNullException("verificationStrategy");
                }
                _verificationStrategy = verificationStrategy;
                return this;
            }

        }

    }
}
