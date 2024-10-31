using System.Text;
using Microsoft.Extensions.Options;
using MyNotifications.DomainModel.Events;
using MyNotifications.Sender.Interfaces;
using MyNotifications.Sender.Models;
using MyNotifications.Sender.Options;
using Newtonsoft.Json;

namespace MyNotifications.Sender.Providers;

public class DiscordMessageProvider : IMessageProvider
{
    private readonly DiscordOptions _discordOptions;
    private const string MediaType = "application/json";

    public DiscordMessageProvider(IOptions<DiscordOptions> discordOptions)
    {
        _discordOptions = discordOptions.Value ?? throw new ArgumentNullException(nameof(discordOptions));
    }
    
    public async Task Execute(DiscordNotificationEvent message, CancellationToken ct = default)
    {
        if (!ValidateNotification(message))
        {
            return;
        }
        
        var request = GetWebhookRequest(message, _discordOptions);
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
            Username = notification.Name ?? nameof(MyNotifications),
        };
    }
}