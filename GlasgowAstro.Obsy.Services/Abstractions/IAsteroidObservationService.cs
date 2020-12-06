using GlasgowAstro.Obsy.Services.Models;
using GlasgowAstro.Obsy.Services.Models.Request;
using GlasgowAstro.Obsy.Services.Models.Response;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Abstractions
{
    public interface IAsteroidObservationService
    {
        Task<AsteroidObservationResponse> GetObservationsAsync(ObservationServiceRequest asteroidObservationRequest);
    }
}
