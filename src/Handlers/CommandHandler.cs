using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace botDiscord.src.Handlers
{

    public class CommandHandler
    {
        private readonly IServiceProvider _services;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public CommandHandler(IServiceProvider services, DiscordSocketClient client, CommandService commands)
        {
            _services = services;
            _client = client;
            _commands = commands;
        }

        public async Task initCommandAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg == null) return;

            if (msg.Author.Id == _client.CurrentUser.Id || msg.Author.IsBot) return;

            int pos = 0;
            if (msg.HasCharPrefix('!', ref pos) || msg.HasMentionPrefix(_client.CurrentUser, ref pos))
            {
                var context = new SocketCommandContext(_client, msg);
                var result = await _commands.ExecuteAsync(context, pos, _services);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                    await msg.Channel.SendMessageAsync(result.ErrorReason);
            }
        }
    }
}