using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;

namespace botDiscord.src.Modules.Commands
{
    public class HelloWorldCommand : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        public async Task HelloCommand()
        {
            await ReplyAsync("world!");
        }
    }
}