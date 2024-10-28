using FastEndpoints;
using MassTransit;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.Api.Handlers;

public class DiscordNotificationEventHandler(IBus bus) : IEventHandler<DiscordNotificationEvent>
{
    public async Task HandleAsync(DiscordNotificationEvent eventModel, CancellationToken ct)
        => await bus.Publish(eventModel, ct);
}