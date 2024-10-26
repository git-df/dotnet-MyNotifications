using MassTransit;
using Microsoft.Extensions.Options;
using MyNotifications.DiscordSender.Consumers;
using MyNotifications.DiscordSender.Options;

namespace MyNotifications.DiscordSender.Extensions;

public static class MassTransitExtension
{
    public static void AddMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<DiscordNotificationEventConsumer>();
    
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitMqOptions = context.GetRequiredService<IOptions<RabbitMqOptions>>().Value;
        
                cfg.Host(new Uri(rabbitMqOptions.Amqp));
        
                cfg.ReceiveEndpoint(rabbitMqOptions.QueueName, e =>
                {
                    e.Bind(rabbitMqOptions.ExchangeName);
                    e.ConfigureConsumer<DiscordNotificationEventConsumer>(context);
                });
            });
        });
    }
}