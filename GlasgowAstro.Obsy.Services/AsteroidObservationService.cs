using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace GlasgowAstro.Obsy.Services
{
    public class AsteroidObservationService : IAsteroidObservationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AsteroidObservationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<AsteroidObservationServiceResponse> GetObservationsAsync(AsteroidObservationServiceRequest asteroidObservationRequest)
        {
            if (asteroidObservationRequest == null || string.IsNullOrWhiteSpace(asteroidObservationRequest.Number))
            {
                return new AsteroidObservationServiceResponse { Number = asteroidObservationRequest.Number, Observations = new List<AsteroidObservation>() };
            }

            // TODO Tidy this up
            var queryArguments = new Dictionary<string, string>()
            {
                { "number", asteroidObservationRequest.Number },
                { "object_type", "M" },
                { "table", "observations" },
                { "limit", "5" },
                { "order_by_desc", "observation_date" },
            };

            var requestUri = QueryHelpers.AddQueryString("/search_db", queryArguments);

            var httpClient = _clientFactory.CreateClient("MpcClient");
            var result = await httpClient.GetAsync(requestUri);

            if (result.IsSuccessStatusCode)
            {                
                var observations = JsonSerializer.Deserialize<List<AsteroidObservation>>(await result.Content.ReadAsStringAsync());
                return new AsteroidObservationServiceResponse { Number = asteroidObservationRequest.Number, Observations = observations };
            }

            return new AsteroidObservationServiceResponse { Number = asteroidObservationRequest.Number, Observations = new List<AsteroidObservation>() };
        }

    }
}
