using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services
{
    public class AsteroidObservationService : IAsteroidObservationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AsteroidObservationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // TODO Request validation + automap. Return AsteroidObservationResponse.
        public async Task<AsteroidObservationResponse> GetObservationsAsync(ObservationServiceRequest asteroidObservationRequest)
        {

            // TODO Map request object to MpcClient request...

            var queryArguments = new Dictionary<string, string>()
            {
                { "number", asteroidObservationRequest.Number },
                { "object_type", "M" },
                { "table", "observations" },
                { "limit", "3" },
                { "order_by_desc", "observation_date" },
            };

            var requestUri = QueryHelpers.AddQueryString("/search_db", queryArguments);

            var client = _clientFactory.CreateClient("MpcClient");
            var result = await client.GetAsync(requestUri);

            var observationResponse = new AsteroidObservationResponse();

            if (result.IsSuccessStatusCode)
            {
                observationResponse.RawTest = await result.Content.ReadAsStringAsync();
            }

            return observationResponse;
        }

    }
}
