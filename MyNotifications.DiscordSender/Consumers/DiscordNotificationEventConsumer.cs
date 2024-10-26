using MassTransit;
using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.DiscordSender.Consumers;

public class DiscordNotificationEventConsumer(IDiscordService discordService) : IConsumer<DiscordNotificationEvent>
{
    public async Task Consume(ConsumeContext<DiscordNotificationEvent> context)
        => await discordService.SendWebhookMessage(context.Message);
}