using MassTransit;
using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.DiscordSender.Consumers;

public class DiscordNotificationEventConsumer : IConsumer<DiscordNotificationEvent>
{
    private readonly IEnumerable<IMessageProvider> _messageProviders;

    public DiscordNotificationEventConsumer(IEnumerable<IMessageProvider> messageProviders)
    {
        _messageProviders = messageProviders;
    }

    public async Task Consume(ConsumeContext<DiscordNotificationEvent> context)
    {
        var messageProvidersTasks = _messageProviders
            .Select(x => x.Execute(context.Message));
        
        await Task.WhenAll(messageProvidersTasks);
    }
}