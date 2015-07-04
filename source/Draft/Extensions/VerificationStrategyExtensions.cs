using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Cluster;

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

        public static async Task<IEnumerable<Uri>> ParallelLoadClusterMembers(this IEnumerable<Uri> This)
        {
            var loadTasks = This.Select(LoadClusterMembers).ToArray();

            await Task.WhenAll(loadTasks);

            return loadTasks.SelectMany(x => x.Result);
        }

        private static async Task<IEnumerable<Uri>> LoadClusterMembers(Uri endpoint)
        {
            try
            {
                var collection = await new NormalizedPathSegment(Constants.Etcd.Path_Members)
                    .ToUrl(endpoint)
                    .GetAsync()
                    .ReceiveJson<ClusterMemberCollection>();
                return collection.Members.SelectMany(x => x.ClientUrls);
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

    }
}
