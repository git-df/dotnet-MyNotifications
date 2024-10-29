namespace MyNotifications.DomainModel.Entities;

public class Log
{
    public int Id { get; set; }
    public required string Source { get; set; }
    public required string Value { get; set; }
    public DateTime Created { get; set; }
}