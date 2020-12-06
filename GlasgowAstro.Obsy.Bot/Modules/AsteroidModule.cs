using Discord;
using Discord.Commands;
using GlasgowAstro.Obsy.Bot.Services;
using System;
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
            // TESTING
            try
            {
                var result = await _obsyApiClient.ObservationsAsync(asteroidNum);

                //var fields = new EmbedFieldBuilder(); // TODO                    

                var embed = new EmbedBuilder() //TODO Move embed building elsewhere
                    .WithTitle($"Recent observations for {asteroidNum}")
                    .WithFooter(footer => footer.Text = "Obsy, a GlasgowAstro bot")
                    .WithCurrentTimestamp()
                    .WithColor(Color.Green)                    
                    .AddField("Observations", result)                    
                    .Build();

                await ReplyAsync(embed: embed);
            }
            catch (Exception e)
            {
                var bla = ""; // TODO
            }

        }
    }
}
