namespace RainyBot.Shared.Options;

public sealed class DiscordOptions
{
    public string Token { get; set; } = string.Empty;
    public long GuildId { get; set; }
}
