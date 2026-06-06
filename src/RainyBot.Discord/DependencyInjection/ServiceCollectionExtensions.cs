using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainyBot.Discord.Services;
using RainyBot.Shared.Options;

namespace RainyBot.Discord.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDiscordServices(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new DiscordOptions
        {
            Token = configuration["Discord:Token"] ?? string.Empty,
            GuildId = long.TryParse(configuration["Discord:GuildId"], out var guildId) ? guildId : 0
        };

        services.AddSingleton(options);
        services.AddHostedService<DiscordBotService>();

        return services;
    }
}
