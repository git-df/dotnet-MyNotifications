using MyNotifications.DiscordSender.Interfaces;
using MyNotifications.DiscordSender.Providers;

namespace MyNotifications.DiscordSender.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageProvider, DiscordMessageProvider>();
        services.AddScoped<IMessageProvider, DatabaseMessageProvider>();
    }
}