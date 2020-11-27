using Discord.Commands;
using Discord.WebSocket;
using GlasgowAstro.Obsy.Bot.Models;
using GlasgowAstro.Obsy.Bot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot
{
    public class Startup
    {
        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup();
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            var serviceProvider = ConfigureServices();
            serviceProvider.GetRequiredService<CommandHandler>(); // Start the command handler
            await serviceProvider.GetRequiredService<BotStartupService>().LaunchBotAsync();
            await Task.Delay(-1); // Keep alive
        }

        private static IServiceProvider ConfigureServices()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("BOT_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "Development";

            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile("appsettings.json", optional: false);
            configBuilder.AddEnvironmentVariables();

            if (isDevelopment)
            {
                configBuilder.AddUserSecrets<BotSettings>(false);
            }

            var config = configBuilder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<BotSettings>(config.GetSection("BotSettings"));
            // TODO Obsy api client
            serviceCollection.AddSingleton(resolver => resolver.GetRequiredService<IOptions<BotSettings>>().Value);    
            serviceCollection.AddSingleton(new DiscordSocketClient());
            serviceCollection.AddSingleton(new CommandService(new CommandServiceConfig
            {
                DefaultRunMode = RunMode.Async
            }));
            serviceCollection.AddSingleton<BotStartupService>();
            serviceCollection.AddSingleton<CommandHandler>();
            // Logging service..
            return serviceCollection.BuildServiceProvider();
        }
    }
}
