using MyNotifications.Api.Options;

namespace MyNotifications.Api.Extensions;

public static class ConfigurationExtension
{
    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(configuration.GetSection(nameof(RabbitMqOptions)));
    }
}