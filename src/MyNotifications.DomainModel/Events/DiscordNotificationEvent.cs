using MyNotifications.DomainModel.Models;

namespace MyNotifications.DomainModel.Events;

public record DiscordNotificationEvent(
    Guid Id,
    WebhookRequest Request);