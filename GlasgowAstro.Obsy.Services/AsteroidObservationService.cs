using GlasgowAstro.Obsy.Services.Abstractions;
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

        // TODO Validation. Return AsteroidObservationResponse.
        public async Task<string> GetObservationsAsync(string asteroidNum) 
        {
            var url = $"/search_db?number={asteroidNum}&object_type=M&table=observations&limit=3";

            //order_by_desc

            var client = _clientFactory.CreateClient("MpcClient");
            var result = await client.GetAsync(url);

            //if (result.IsSuccessStatusCode)
            //{
            //    return await result.Content.ReadAsStringAsync();
            //}
            var test = "";

            return await result.Content.ReadAsStringAsync();  // TODO 
        }

    }
}
