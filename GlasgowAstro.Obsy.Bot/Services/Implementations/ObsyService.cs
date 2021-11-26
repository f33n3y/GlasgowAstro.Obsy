using GlasgowAstro.Obsy.Bot.Helpers;
using GlasgowAstro.Obsy.Bot.Models;
using GlasgowAstro.Obsy.Bot.Services.Contracts;
using System;
using System.Linq;
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

        public async Task<AsteroidBotEmbedData> GetAsteroidData(string asteroidNum)
        {
            var botEmbedData = new AsteroidBotEmbedData();

            try
            {
                var observationsCall = _obsyApiClient.ObservationsAsync(asteroidNum);
                var orbitCall = _obsyApiClient.OrbitsAsync(asteroidNum);
                var (observationData, orbitData) = await TaskExt.WhenAll(observationsCall, orbitCall);

                if (observationData.Status == TaskStatus.RanToCompletion)
                {
                    var observationResult = observationData.Result;
                    // TODO ... Automapper 
                    botEmbedData.Number = observationResult.Number;
                    foreach (var observation in observationResult.Observations)
                    {
                        botEmbedData.Observations.Add(new Models.Observation
                        {
                            ObservationDate = observation.ObservationDate
                        });
                    }    
                    
                }

                if (orbitData.Status == TaskStatus.RanToCompletion)
                {
                    var orbitResult = orbitCall.Result;
                    botEmbedData.AbsoluteMagnitude = orbitResult.OrbitData.FirstOrDefault()?.AbsoluteMagnitude;
              
                }
            }
            catch (Exception e)
            {                
                // TODO Logging
            }

            return botEmbedData;
        }
    }
}
