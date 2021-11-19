using GlasgowAstro.Obsy.Bot.Models;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Services.Contracts
{
    public interface IObsyService
    {
        Task<AsteroidBotEmbedData> GetAsteroidData(string asteroidNum);
    }
}
