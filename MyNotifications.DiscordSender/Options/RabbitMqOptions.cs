namespace MyNotifications.DiscordSender.Options;

public class RabbitMqOptions
{
    public required string Amqp { get; init; }
    public required string ExchangeName { get; init; }
    public required string QueueName { get; init; }
}