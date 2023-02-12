using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using botDiscord.src.Handlers;

public class DandaraBot
{
    private readonly IServiceProvider _serviceProvider;

    public DandaraBot()
    {
        _serviceProvider = ConfigureService();
    }

    private static IServiceProvider ConfigureService()
    {
        IConfiguration configuration;
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("src/appsettings.Development.json")
            .Build();

        var collectionContainer = new ServiceCollection()
        .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig()
        {
            LogLevel = LogSeverity.Info,
        }))
        .AddSingleton(new CommandService(new CommandServiceConfig()
        {
            LogLevel = LogSeverity.Info,
            CaseSensitiveCommands = true,
        }))
        .AddSingleton<ClientHandler>();

        return collectionContainer.BuildServiceProvider();
    }

    public async Task InitBotAsync()
    {
        await _serviceProvider.GetRequiredService<ClientHandler>().ConnectClientAsync();
        await _serviceProvider.GetRequiredService<CommandHandler>().initCommandAsync();
    }
}