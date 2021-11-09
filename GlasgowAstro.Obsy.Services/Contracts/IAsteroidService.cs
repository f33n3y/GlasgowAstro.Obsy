using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Contracts
{
    public interface IAsteroidService
    {
        Task<AsteroidObservationDataResponse> GetObservationsAsync(AsteroidObservationDataRequest asteroidObservationDataRequest);

        Task<AsteroidOrbitDataResponse> GetOrbitDataAsync(AsteroidOrbitDataRequest asteroidOrbitDataRequest);
    }
}
