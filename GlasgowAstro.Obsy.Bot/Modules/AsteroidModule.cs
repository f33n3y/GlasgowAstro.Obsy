using Discord;
using Discord.Commands;
using GlasgowAstro.Obsy.Bot.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Modules
{
    public class AsteroidModule : ModuleBase<SocketCommandContext>
    {
        private readonly ObsyApiClient _obsyApiClient;

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

                //TODO Move field building elsewhere
                var fieldBuilders = new List<EmbedFieldBuilder>();
                foreach (var observation in result.Observations)
                {
                    var builder = new EmbedFieldBuilder();
                    builder.Name = $"Observation: {observation.ObservationDate}";
                    builder.Value = $"Observatory code: {observation.ObservatoryCode}";
                    fieldBuilders.Add(builder);
                }

                //TODO Move embed building elsewhere
                var embed = new EmbedBuilder()
                    .WithTitle($"Recent observations for {result.Number}")
                    .WithFooter(footer => footer.Text = "Obsy, a GlasgowAstro bot")
                    .WithThumbnailUrl("https://www.glasgowastro.co.uk/images/logo.jpg")
                    .WithCurrentTimestamp()
                    .WithColor(new Color(0xE7AB1F))
                    .WithFields(fieldBuilders)
                    .Build();

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
