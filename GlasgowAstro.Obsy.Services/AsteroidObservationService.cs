using GlasgowAstro.Obsy.Services.Abstractions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services
{
    public class AsteroidObservationService : IAsteroidObservationService
    {
        // inject HTTP client to call MPC search service

        public AsteroidObservationService()
        {
            // HTTP client
        }

        /// <summary>
        /// TESTING TESTING TESTING
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetObservationsAsync(string id)
        {
            // Note: These auth creds for the MPC web service are already publicly available:           
            // https://minorplanetcenter.net/web_service/
            var userName = "mpc_ws";
            var passwd = "mpc!!ws";
            var url = $"https://minorplanetcenter.net/search_db?number={id}&object_type=M&table=observations&limit=3";

            var testClient = new HttpClient(); // TODO Inject me!
            var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));         
            var result = await testClient.GetAsync(url);
            return await result.Content.ReadAsStringAsync();
        }

    }
}
