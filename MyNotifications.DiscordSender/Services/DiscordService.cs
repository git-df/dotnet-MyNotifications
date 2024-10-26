using System.Text;
using Microsoft.Extensions.Options;
using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DiscordSender.Models;
using MyNotifications.DiscordSender.Options;
using MyNotifications.DomainModel.Events;
using Newtonsoft.Json;

namespace MyNotifications.DiscordSender.Services;

public class DiscordService : IDiscordService
{
    private readonly DiscordOptions _discordOptions;
    private const string MediaType = "application/json";

    public DiscordService(IOptions<DiscordOptions> discordOptions)
    {
        _discordOptions = discordOptions.Value ?? throw new ArgumentNullException(nameof(discordOptions));
    }
    
    public async Task SendWebhookMessage(DiscordNotificationEvent notification, CancellationToken ct = default)
    {
        if (!ValidateNotification(notification))
        {
            return;
        }
        
        var request = GetWebhookRequest(notification, _discordOptions);
        var jsonRequest = JsonConvert.SerializeObject(request);
        var stringContent = new StringContent(jsonRequest, Encoding.UTF8, MediaType);

        using HttpClient client = new HttpClient();
        await client.PostAsync(_discordOptions.WebhookUrl, stringContent, ct);
    }

    private static bool ValidateNotification(DiscordNotificationEvent notification)
    {
        return !string.IsNullOrWhiteSpace(notification.Content);
    }
    
    private static WebhookRequest GetWebhookRequest(DiscordNotificationEvent notification, DiscordOptions discordOptions)
    {
        return new WebhookRequest
        {
            Content = notification.Content,
            Username = discordOptions.Username
        };
    }
}