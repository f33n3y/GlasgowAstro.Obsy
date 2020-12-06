using GlasgowAstro.Obsy.Services.Models.Response;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Services.Abstractions
{
    public interface IAsteroidDataService
    {
        Task<AsteroidDataResponse> FindAsteroidByNameAsync(string name);
    }
}
