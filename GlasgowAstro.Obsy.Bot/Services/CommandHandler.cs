using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace GlasgowAstro.Obsy.Bot.Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _provider;

        public CommandHandler(DiscordSocketClient client, CommandService commandService, IServiceProvider provider)
        {
            _commandService = commandService;
            _client = client;
            _provider = provider;
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage socketMsg)
        {
            // Check message is a valid command and is not from another bot
            var message = socketMsg as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;
            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            // Create command context based on the message
            var context = new SocketCommandContext(_client, message);

            var result = await _commandService.ExecuteAsync(context, argPos, _provider);

            //if (!result.IsSuccess)
            //{
            //    await context.Channel.SendMessageAsync(result.ToString());
            //}
        }
    }
}

