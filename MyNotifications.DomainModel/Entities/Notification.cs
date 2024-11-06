namespace MyNotifications.DomainModel.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public DateTime? Send { get; set; }
    public DateTime Created { get; set; }
}