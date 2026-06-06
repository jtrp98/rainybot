using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RainyBot.Shared.Options;

namespace RainyBot.Discord.Services;

public sealed class DiscordBotService : BackgroundService
{
    private readonly ILogger<DiscordBotService> _logger;
    private readonly DiscordOptions _options;

    public DiscordBotService(ILogger<DiscordBotService> logger, DiscordOptions options)
    {
        _logger = logger;
        _options = options;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Discord bot service starting. GuildId={GuildId}", _options.GuildId);

        return Task.CompletedTask;
    }
}
