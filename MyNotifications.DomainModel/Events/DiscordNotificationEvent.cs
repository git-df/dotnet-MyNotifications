namespace MyNotifications.DomainModel.Events;

public record DiscordNotificationEvent(
    string? Name,
    string Content);