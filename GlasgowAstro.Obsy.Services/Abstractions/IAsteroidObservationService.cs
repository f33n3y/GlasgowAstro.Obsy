using GlasgowAstro.Obsy.Services.Models;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Abstractions
{
    public interface IAsteroidObservationService
    {
        Task<AsteroidObservationResponse> GetObservationsAsync(string id);
    }
}
