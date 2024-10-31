using MyNotifications.Sender.Interfaces;
using MyNotifications.Sender.Providers;

namespace MyNotifications.Sender.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageProvider, DiscordMessageProvider>();
        services.AddScoped<IMessageProvider, DatabaseMessageProvider>();
    }
}