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
                await ReplyAsync(await _obsyApiClient.ObservationsAsync(asteroidNum));
            }
            catch (Exception e)
            {
                var bla = ""; // TODO
            }

        }
    }
}
