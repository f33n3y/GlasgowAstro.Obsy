using GlasgowAstro.Obsy.Bot.Helpers;
using GlasgowAstro.Obsy.Bot.Models;
using GlasgowAstro.Obsy.Bot.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Services.Implementations
{
    public class ObsyService : IObsyService
    {
        private readonly ObsyApiClient _obsyApiClient;

        public ObsyService(ObsyApiClient obsyApiClient)
        {
            _obsyApiClient = obsyApiClient;
        }

        public async Task<AsteroidData> GetAsteroidData(string asteroidNum)
        {
            var asteroidData = new AsteroidData();
            var observationsCall = _obsyApiClient.ObservationsAsync(asteroidNum);
            var orbitCall = _obsyApiClient.OrbitsAsync(asteroidNum);

            try
            {
                var (observationData, orbitData) = await TaskExt.WhenAll(observationsCall, orbitCall);

                if (observationData.Status == TaskStatus.RanToCompletion)
                {
                    var result = observationData.Result;
                    //asteroidData.Number = result.Number;
                    // ...
                }

                if (orbitData.Status == TaskStatus.RanToCompletion)
                {
                    var result = orbitCall.Result;
                    // ...
                }
            }
            catch (Exception e)
            {                
                // TODO Logging
            }

            return new AsteroidData();            
        }
    }
}
