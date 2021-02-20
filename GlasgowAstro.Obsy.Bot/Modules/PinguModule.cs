using Discord.Commands;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Modules
{    
    /// <summary>
    /// A test module
    /// </summary>
    public class PinguModule : ModuleBase<SocketCommandContext>
    {        
        [Command("noot")]
        [Summary("Makes pingu noot")]
        public Task NootAsync() => ReplyAsync("Noot Noot! 🐧");

        [Command("hello")]
        [Summary("Says hello")]
        public Task HelloAsync() => ReplyAsync("Hello friend");
    }
}
