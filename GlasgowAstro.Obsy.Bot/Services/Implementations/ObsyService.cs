using GlasgowAstro.Obsy.Bot.Services.Contracts;

namespace GlasgowAstro.Obsy.Bot.Services.Implementations
{
    // TODO: A facade method that takes asteroid number and uses ObsyApiClient to call both 
    // the Observation and Orbit data endpoints and gather all the data needed for Discord embed card
    public class ObsyService : IObsyService
    {
        private readonly ObsyApiClient _obsyApiClient;

        public ObsyService(ObsyApiClient obsyApiClient)
        {
            _obsyApiClient = obsyApiClient;
        }


    }
}
