using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Draft.Exceptions;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class VerificationStrategyClusterMembers : EndpointVerificationStrategy
    {

        private async Task<List<Endpoint>> DoVerify(IEnumerable<Uri> uris)
        {
            return (await uris.ParallelValidateEndpoints()).ToList();
        }

        public override async Task<IEnumerable<Endpoint>> Verify(IEnumerable<Uri> endpointUris)
        {
            var uris = (endpointUris ?? Enumerable.Empty<Uri>()).ToList();
            var endpoints = await DoVerify(uris);

            var distinctEndpoints = new HashSet<Endpoint>(endpoints.Where(x => x.IsOnline));

            if (!distinctEndpoints.Any())
            {
                throw new InvalidHostException(
                    string.Format(
                        "The following endpoints are not responding: {0}",
                        string.Join(", ", uris.Select(x => x.ToString()))
                        ));
            }

            var memberUris = (await distinctEndpoints.Select(x => x.Uri).ParallelLoadClusterMembers()).ToList();
            var verifiedMemberEndpoints = await DoVerify(memberUris);

            verifiedMemberEndpoints
                .ForEach(x => distinctEndpoints.Add(x));

            return distinctEndpoints;
        }

    }
}
