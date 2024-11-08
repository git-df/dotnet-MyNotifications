using MyNotifications.DomainModel.Models;

namespace MyNotifications.Sender.Interfaces;

public interface IDiscordRepository
{
    Task SendWebhook(WebhookRequest request, CancellationToken ct = default);
}