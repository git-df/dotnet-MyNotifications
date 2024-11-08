using Microsoft.EntityFrameworkCore;
using MyNotifications.Database;
using MyNotifications.DomainModel.Entities;
using MyNotifications.DomainModel.Events;
using MyNotifications.DomainModel.Validators;
using MyNotifications.Sender.Extensions;
using MyNotifications.Sender.Interfaces;
using Newtonsoft.Json;

namespace MyNotifications.Sender.Services;

public class NotificationsService : INotificationsService
{
    private readonly IDiscordRepository _discordRepository;
    private readonly MnDbContext _context;

    public NotificationsService(IDiscordRepository discordRepository, MnDbContext context)
    {
        _discordRepository = discordRepository;
        _context = context;
    }
    
    public async Task ProcessNotificationEvent(DiscordNotificationEvent notificationEvent, CancellationToken ct = default)
    {
        if (!notificationEvent.IsValid<DiscordNotificationEvent, DiscordNotificationEventValidator>())
            return;
        
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(x => x.Id == notificationEvent.Id, ct);
        
        var now = DateTime.UtcNow;
        if (notification == null)
        {
            var jsonRequest = JsonConvert.SerializeObject(notificationEvent.Request, Formatting.Indented);
            notification = new Notification
            {
                Content = jsonRequest,
                Created = now,
                Send = now
            };
            
            _context.Notifications.Add(notification);
        }
        else
        {
            notification.Send = now;
        }
        
        await _context.SaveChangesAsync(ct);
        
        await _discordRepository.SendWebhook(notificationEvent.Request, ct);
    }
}