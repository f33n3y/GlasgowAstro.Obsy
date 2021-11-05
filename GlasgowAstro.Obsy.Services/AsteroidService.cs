using GlasgowAstro.Obsy.Services.Abstractions;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services
{
    public class AsteroidService : IAsteroidService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AsteroidService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Uses HTTPClient to make query against Minor Planet Centre's Observations Table
        /// </summary>
        /// <param name="asteroidObservationDataRequest"></param>
        /// <returns></returns>
        public async Task<AsteroidObservationDataResponse> GetObservationsAsync(AsteroidObservationDataRequest asteroidObservationDataRequest)
        {
            if (asteroidObservationDataRequest is null || string.IsNullOrWhiteSpace(asteroidObservationDataRequest.Number))
            {
                return new AsteroidObservationDataResponse { Number = asteroidObservationDataRequest.Number, Observations = new List<AsteroidObservation>() };
            }

            // TODO Tidy this up
            var queryArguments = new Dictionary<string, string>()
            {
                { "number", asteroidObservationDataRequest.Number },
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
                return new AsteroidObservationDataResponse { Number = asteroidObservationDataRequest.Number, Observations = observations };
            }

            return new AsteroidObservationDataResponse { Number = asteroidObservationDataRequest.Number, Observations = new List<AsteroidObservation>() };
        }

        /// <summary>
        /// Uses HTTPClient to make query against Minor Planet Centre's Orbits Table
        /// </summary>
        /// <param name="asteroidOrbitDataRequest"></param>
        /// <returns></returns>
        public async Task<AsteroidOrbitDataResponse> GetOrbitDataAsync(AsteroidOrbitDataRequest asteroidOrbitDataRequest)
        {
            if (asteroidOrbitDataRequest is null || string.IsNullOrWhiteSpace(asteroidOrbitDataRequest.Number))
            {
                return new AsteroidOrbitDataResponse { OrbitData = new AsteroidOrbitData { AbsoluteMagnitude = string.Empty } };
            }

            var queryArguments = new Dictionary<string, string>()
            {
                { "number", asteroidOrbitDataRequest.Number },
                { "table", "orbits" },
            };

            var requestUri = QueryHelpers.AddQueryString("/search_db", queryArguments);

            var httpClient = _clientFactory.CreateClient("MpcClient");
            var result = await httpClient.GetAsync(requestUri);

            if (result.IsSuccessStatusCode)
            {
                var orbitData = JsonSerializer.Deserialize<AsteroidOrbitData>(await result.Content.ReadAsStringAsync());
                return new AsteroidOrbitDataResponse { OrbitData = orbitData };
            }

            return new AsteroidOrbitDataResponse { OrbitData = new AsteroidOrbitData { AbsoluteMagnitude = string.Empty } };
        }
    }
}
