using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.DiscordSender.Providers;

public class DatabaseMessageProvider : IMessageProvider
{
    public async Task Execute(DiscordNotificationEvent message, CancellationToken ct = default)
    {
        Console.WriteLine(message.Content);
    }
}