using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace botDiscord.src.Handlers
{
    public class LoggingHandler
    {
        public LoggingHandler(DiscordSocketClient client, CommandService command)
        {
            client.Log += Log;
            command.Log += Log;
        }

        private Task Log(LogMessage message)
        {
            if (message.Exception is CommandException commandException)
            {
                Console.WriteLine($"[Command/{message.Severity}] {commandException.Command.Aliases.First()} " +
                    $"failed to execute in {commandException.Context.Channel}.");
                Console.WriteLine(commandException);
            }
            else
            {
                Console.WriteLine($"[General/{message.Severity}] {message}");
            }

            return Task.CompletedTask;
        }
    }
}