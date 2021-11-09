using Discord;
using Discord.Commands;
using GlasgowAstro.Obsy.Bot.EmbedBuilders;
using GlasgowAstro.Obsy.Bot.Services;
using System;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Modules
{
    public class AsteroidModule : ModuleBase<SocketCommandContext>
    {
        private readonly ObsyApiClient _obsyApiClient; // Change this to inject facade instead

        public AsteroidModule(ObsyApiClient obsyApiClient)
        {
            _obsyApiClient = obsyApiClient;
        }

        [Command("obsy")]
        [Summary("Returns previous observations for an asteroid")]
        public async Task GetObservationsAsync([Summary("The asteroid's number")] string asteroidNum)
        {
            try
            {
                var result = await _obsyApiClient.ObservationsAsync(asteroidNum);

                //if (result.) // TODO
                
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
