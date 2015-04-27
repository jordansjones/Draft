using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Draft.Endpoints;

using Flurl.Http;

namespace Draft
{
    internal static class VerificationStrategyExtensions
    {

        public static async Task<IEnumerable<Endpoint>> ParallelValidateEndpoints(this IEnumerable<Uri> This)
        {
            var validationTasks = This.Select(ValidateEndpoint)
                .ToArray();

            await Task.WhenAll(validationTasks);

            return validationTasks
                .Select(x => x.Result);
        }

        private static async Task<Endpoint> ValidateEndpoint(Uri endpoint)
        {
            var availablility = EndpointAvailability.Offline;
            try
            {
                var response = await endpoint.ToUrl()
                                             .AppendPathSegment(Constants.Etcd.Path_Version)
                                             .GetAsync();
                if (response != null && response.IsSuccessStatusCode)
                {
                    availablility = EndpointAvailability.Online;
                }

            }
            catch
            {
                // Failed, don't do anything
            }

            return new Endpoint(endpoint, availablility);
        }

    }
}
