using Discord;
using Discord.Commands;
using GlasgowAstro.Obsy.Bot.EmbedBuilders;
using GlasgowAstro.Obsy.Bot.Services;
using GlasgowAstro.Obsy.Bot.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Modules
{
    public class AsteroidModule : ModuleBase<SocketCommandContext>
    {
        private readonly ObsyApiClient _obsyApiClient; // TODO Remove this once facade implementation complete
        private readonly IObsyService _obsyService;

        public AsteroidModule(ObsyApiClient obsyApiClient, IObsyService obsyService)
        {
            _obsyApiClient = obsyApiClient;
            _obsyService = obsyService;
        }

        [Command("obsy")]
        [Summary("Returns previous observations for an asteroid")]
        public async Task GetObservationsAsync([Summary("The asteroid's number")] string asteroidNum)
        {
            try
            {
                var result = await _obsyApiClient.ObservationsAsync(asteroidNum);
                // TODO 
                //var asteroidData = await _obsyService.GetAsteroidData(asteroidNum);
                //if (asteroidData == null || asteroidData...)                

                var embedFieldsList = EmbedFactory.CreateEmbedList();
                foreach (var observation in result.Observations)
                {
                    var embedField = EmbedFactory.CreateEmbedField($"Observation: {observation.ObservationDate}", 
                        $"Observatory code: {observation.ObservatoryCode}");
                    embedFieldsList.Add(embedField);
                }

                var embed = EmbedFactory.CreateEmbedWithFields($"Recent observations for {result.Number}",
                    "Obsy, a GlasgowAstro bot", "https://www.glasgowastro.co.uk/images/logo.jpg", new Color(0xE7AB1F),
                    embedFieldsList);

                await ReplyAsync(embed: embed);
            }
            catch (Exception e)
            {
                // TODO Logging
                await ReplyAsync("We have a problem!");
            }

        }
    }
}
