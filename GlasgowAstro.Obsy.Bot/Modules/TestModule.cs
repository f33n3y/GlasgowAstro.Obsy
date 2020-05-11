using Discord.Commands;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Modules
{
    public class TestModule : ModuleBase<SocketCommandContext>
    {
        // ~say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);
    }
}
