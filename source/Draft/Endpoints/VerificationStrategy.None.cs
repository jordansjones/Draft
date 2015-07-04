using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Draft.Endpoints
{
    [Serializable, DataContract]
    internal sealed class VerificationStrategyNone : EndpointVerificationStrategy
    {

        public override Task<IEnumerable<Endpoint>> Verify(IEnumerable<Uri> endpointUris)
        {
            return Task.FromResult<IEnumerable<Endpoint>>(endpointUris.Select(x => new Endpoint(x, EndpointAvailability.Online)).ToList());
        }

    }
}
