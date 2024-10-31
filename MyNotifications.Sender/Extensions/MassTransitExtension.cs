using MassTransit;
using Microsoft.Extensions.Options;
using MyNotifications.Sender.Options;

namespace MyNotifications.Sender.Extensions;

public static class MassTransitExtension
{
    public static void AddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(Program).Assembly);
            x.UsingRabbitMq((context, cfg) =>
            {
                var options = context.GetRequiredService<IOptions<RabbitMqOptions>>().Value;
        
                cfg.ConfigureEndpoints(context);
                cfg.Host(options.HostUri);
            });
        });
    }
}