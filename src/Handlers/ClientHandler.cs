using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace botDiscord.src.Handlers
{
    public class ClientHandler
    {
        private readonly IConfiguration _configuration;
        private readonly DiscordSocketClient _client;

        public ClientHandler(IConfiguration configuration, DiscordSocketClient client)
        {
            _configuration = configuration;
            _client = client;
        }

        public async Task ConnectClientAsync()
        {
            string token = _configuration.GetSection("Discord")["TokenDiscord"];
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
    }
}