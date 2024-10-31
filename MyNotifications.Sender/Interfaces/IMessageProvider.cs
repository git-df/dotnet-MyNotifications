using MyNotifications.DomainModel.Events;

namespace MyNotifications.Sender.Interfaces;

public interface IMessageProvider
{
    Task Execute(DiscordNotificationEvent message, CancellationToken ct = default);
}