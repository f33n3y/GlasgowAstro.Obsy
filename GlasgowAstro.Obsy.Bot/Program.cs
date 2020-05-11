using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot
{
    public class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
			IServiceProvider provider = ConfigureServices();
			
            // Testing
            var _client = new DiscordSocketClient();
			Console.WriteLine("Starting bot");
			await _client.LoginAsync(TokenType.Bot, "");
			Console.WriteLine("Logged In");
			await _client.StartAsync();
	
			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // TODO ...
          
            return serviceCollection.BuildServiceProvider();
        }
    }
}
