using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Abstractions
{
    public interface IAsteroidObservationService
    {
        Task<string> GetObservationsAsync(string id);
    }
}
