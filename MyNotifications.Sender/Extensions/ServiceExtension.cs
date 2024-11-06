using MyNotifications.Sender.Interfaces;
using MyNotifications.Sender.Repositories;
using MyNotifications.Sender.Services;

namespace MyNotifications.Sender.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDiscordRepository, DiscordRepository>();
        services.AddScoped<INotificationsService, NotificationsService>();
    }
}