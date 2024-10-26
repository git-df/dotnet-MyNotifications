using MyNotifications.DomainModel.Events;

namespace MyNotifications.DiscordSender.Interfaces;

public interface IDiscordService
{
    Task SendWebhookMessage(DiscordNotificationEvent notification, CancellationToken ct = default);
}