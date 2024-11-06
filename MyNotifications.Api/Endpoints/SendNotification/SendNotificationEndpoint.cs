using FastEndpoints;
using MyNotifications.DomainModel.Events;
using MyNotifications.DomainModel.Models;

namespace MyNotifications.Api.Endpoints.SendNotification;

public class SendNotificationEndpoint : Endpoint<SendNotificationRequest>
{
    public override void Configure()
    {
        Post("notifications");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SendNotificationRequest req, CancellationToken ct)
    {
        var id = Guid.NewGuid();
        
        await PublishAsync(new DiscordNotificationEvent(id, req.Request), Mode.WaitForNone, ct);
        await SendAsync(id, StatusCodes.Status201Created, ct);
    }
}

public record SendNotificationRequest(
    WebhookRequest Request);