using Discord.Commands;
using Discord.WebSocket;
using GlasgowAstro.Obsy.Bot.Models;
using GlasgowAstro.Obsy.Bot.Services;
using GlasgowAstro.Obsy.Bot.Services.Contracts;
using GlasgowAstro.Obsy.Bot.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

            var httpClient = new HttpClient();
            var username = config.GetValue<string>("ObsyApiUsername");
            var pw = config.GetValue<string>("ObsyApiPassword");
            var authToken = Encoding.ASCII.GetBytes($"{username}:{pw}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
            serviceCollection.AddSingleton(new ObsyApiClient(config.GetValue<string>("ObsyApiBaseUrl"), httpClient));
            serviceCollection.AddSingleton<IObsyService, ObsyService>();

            serviceCollection.Configure<BotSettings>(config.GetSection("BotSettings"));
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
