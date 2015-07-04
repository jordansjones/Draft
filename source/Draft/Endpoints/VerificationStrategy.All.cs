using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Draft.Exceptions;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class VerificationStrategyAll : EndpointVerificationStrategy
    {

        public override async Task<IEnumerable<Endpoint>> Verify(IEnumerable<Uri> endpointUris)
        {
            var uris = endpointUris.ToList();
            var endpoints = (await uris.ParallelValidateEndpoints()).ToList();

            if (endpoints.All(x => x.IsOnline)) return endpoints;

            throw new InvalidHostException(
                string.Format(
                    "The selected verification strategy requires all passed endpoints to respond. The following are not responding: {0}",
                    string.Join(", ", endpoints.Where(x => !x.IsOnline).Select(x => x.Uri.ToString()))
                    ));
        }

    }
}
