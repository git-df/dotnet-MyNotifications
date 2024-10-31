using MyNotifications.Sender.Options;

namespace MyNotifications.Sender.Extensions;

public static class ConfigurationExtension
{
    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DiscordOptions>(configuration.GetSection(nameof(DiscordOptions)));
        services.Configure<RabbitMqOptions>(configuration.GetSection(nameof(RabbitMqOptions)));
    }
}