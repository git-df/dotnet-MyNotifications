using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DiscordSender.Services;

namespace MyNotifications.DiscordSender.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDiscordService, DiscordService>();
    }
}