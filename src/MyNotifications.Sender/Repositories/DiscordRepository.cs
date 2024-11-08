using System.Text;
using Microsoft.Extensions.Options;
using MyNotifications.DomainModel.Models;
using MyNotifications.Sender.Interfaces;
using MyNotifications.Sender.Options;
using Newtonsoft.Json;

namespace MyNotifications.Sender.Repositories;

public class DiscordRepository : IDiscordRepository
{
    private readonly DiscordOptions _discordOptions;
    private const string MediaType = "application/json";

    public DiscordRepository(IOptions<DiscordOptions> discordOptions)
    {
        _discordOptions = discordOptions.Value ?? throw new ArgumentNullException(nameof(discordOptions));
    }
    
    public async Task SendWebhook(WebhookRequest request, CancellationToken ct = default)
    {
        if (!ValidateNotification(request))
        {
            return;
        }
        
        var jsonRequest = JsonConvert.SerializeObject(request, Formatting.Indented);
        var stringContent = new StringContent(jsonRequest, Encoding.UTF8, MediaType);

        using HttpClient client = new HttpClient();
        await client.PostAsync(_discordOptions.WebhookUrl, stringContent, ct);
    }
    
    private static bool ValidateNotification(WebhookRequest request)
    {
        return !string.IsNullOrWhiteSpace(request.Content);
    }
}