namespace MyNotifications.DiscordSender.Options;

public class DiscordOptions
{
    public required string WebhookUrl { get; init; }
    public required string Username { get; init; }
}