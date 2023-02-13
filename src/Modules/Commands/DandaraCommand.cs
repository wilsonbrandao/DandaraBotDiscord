using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using botDiscord.src.Services;
using Discord.Commands;

namespace botDiscord.src.Modules.Commands
{
    public class DandaraCommand : ModuleBase<SocketCommandContext>
    {
        private readonly OpenApiService _openAiService;

        public DandaraCommand(OpenApiService openAiService)
        {
            _openAiService = openAiService;
        }

        [Command("dandara")]
        [Summary("Echoes a message.")]
        public async Task dandataCommand([Remainder][Summary("The text to echo")] string prompText)
        {
            var response = await _openAiService.Request(prompText);

            if (response.IsSuccess)
            {
                var message = response.Successes[0].Message;
                await ReplyAsync(message);
            }
            else
            {
                await ReplyAsync("Desculpe, não consegui processar :(");
            }
        }
    }
}