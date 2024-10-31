using MyNotifications.DomainModel.Events;
using MyNotifications.Sender.Interfaces;

namespace MyNotifications.Sender.Providers;

public class DatabaseMessageProvider : IMessageProvider
{
    public async Task Execute(DiscordNotificationEvent message, CancellationToken ct = default)
    {
        Console.WriteLine(message.Content);
    }
}