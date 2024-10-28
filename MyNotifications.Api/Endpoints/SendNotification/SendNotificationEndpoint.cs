using FastEndpoints;
using MyNotifications.DomainModel.Events;

namespace MyNotifications.Api.Endpoints.SendNotification;

public class SendNotificationEndpoint : Endpoint<DiscordNotificationEvent>
{
    private const string Message = "Notification created";
    
    public override void Configure()
    {
        Post("notifications");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DiscordNotificationEvent req, CancellationToken ct)
    {
        await PublishAsync(req, Mode.WaitForNone, ct);
        await SendAsync(Message, StatusCodes.Status201Created, ct);
    }
}