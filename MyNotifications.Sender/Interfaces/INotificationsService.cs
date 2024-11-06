using MyNotifications.DomainModel.Events;

namespace MyNotifications.Sender.Interfaces;

public interface INotificationsService
{
    Task ProcessNotificationEvent(DiscordNotificationEvent notificationEvent, CancellationToken ct = default);
}