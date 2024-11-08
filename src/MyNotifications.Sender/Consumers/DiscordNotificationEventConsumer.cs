using MassTransit;
using MyNotifications.DomainModel.Events;
using MyNotifications.Sender.Interfaces;

namespace MyNotifications.Sender.Consumers;

public class DiscordNotificationEventConsumer : IConsumer<DiscordNotificationEvent>
{
    private readonly INotificationsService _notificationsService;

    public DiscordNotificationEventConsumer(INotificationsService notificationsService)
    {
        _notificationsService = notificationsService;
    }

    public async Task Consume(ConsumeContext<DiscordNotificationEvent> context)
        => await _notificationsService.ProcessNotificationEvent(context.Message, CancellationToken.None);
}