using MyNotifications.DomainModel.Events;
using MyNotifications.Sender.Interfaces;

namespace MyNotifications.Sender.Services;

public class NotificationsService : INotificationsService
{
    private readonly IDiscordRepository _discordRepository;

    public NotificationsService(IDiscordRepository discordRepository)
    {
        _discordRepository = discordRepository;
    }
    
    public async Task ProcessNotificationEvent(DiscordNotificationEvent notificationEvent, CancellationToken ct = default)
    {
        await _discordRepository.SendWebhook(notificationEvent.Request, ct);
    }
}