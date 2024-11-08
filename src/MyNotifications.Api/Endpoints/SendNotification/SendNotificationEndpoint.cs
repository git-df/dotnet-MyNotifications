using FastEndpoints;
using MyNotifications.Database;
using MyNotifications.DomainModel.Entities;
using MyNotifications.DomainModel.Events;
using MyNotifications.DomainModel.Models;
using Newtonsoft.Json;

namespace MyNotifications.Api.Endpoints.SendNotification;

public class SendNotificationEndpoint : Endpoint<SendNotificationRequest>
{
    private readonly MnDbContext _context;

    public SendNotificationEndpoint(MnDbContext context)
    {
        _context = context;
    }
    
    public override void Configure()
    {
        Post("notifications");
        Validator<SendNotificationValidator>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(SendNotificationRequest req, CancellationToken ct)
    {
        var jsonRequest = JsonConvert.SerializeObject(req.Request, Formatting.Indented);
        var notification = new Notification
        {
            Content = jsonRequest,
            Created = DateTime.UtcNow,
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync(ct);
        
        if (notification.Id == Guid.Empty)
        {
            await SendErrorsAsync(cancellation: ct);
        }
        
        await PublishAsync(new DiscordNotificationEvent(notification.Id, req.Request), Mode.WaitForNone, ct);
        await SendAsync(notification.Id, StatusCodes.Status201Created, ct);
    }
}

public record SendNotificationRequest(
    WebhookRequest Request);