using MyNotifications.DomainModel.Events;

namespace MyNotifications.DiscordSender.Interfaces;

public interface IMessageProvider
{
    Task Execute(DiscordNotificationEvent message, CancellationToken ct = default);
}