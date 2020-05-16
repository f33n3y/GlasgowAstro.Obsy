using Discord;
using Discord.Commands;
using Discord.WebSocket;
using GlasgowAstro.Obsy.Bot.Models;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Services
{
    public class BotStartupService
    {
        private readonly IServiceProvider _provider;
        private readonly DiscordSocketClient _discord;
        private readonly CommandService _commands;
        private readonly BotSettings _config;

        public BotStartupService(IServiceProvider provider, DiscordSocketClient discord, CommandService commands, BotSettings config)
        {
            _provider = provider;
            _discord = discord;
            _commands = commands;
            _config = config;
        }


        public async Task LaunchBotAsync()
        {
            await _discord.LoginAsync(TokenType.Bot, _config.DiscordToken);
            await _discord.StartAsync();
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _provider); // Load commands and modules into command service
        }
    }
}
