using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Draft.Exceptions;

namespace Draft.Endpoints
{
    internal sealed class VerificationStrategyAny : EndpointVerificationStrategy
    {

        public override async Task<IEnumerable<Endpoint>> Verify(IEnumerable<Uri> endpointUris)
        {
            var uris = endpointUris.ToList();
            var endpoints = (await uris.ParallelValidateEndpoints()).ToList();

            if (endpoints.Any(x => x.IsOnline)) return endpoints;

            throw new InvalidHostException(string.Format(
                "The following endpoints are not responding: {0}",
                string.Join(", ", uris.Select(x => x.ToString()))
                ));
        }

    }
}
