using Microsoft.EntityFrameworkCore;
using MyNotifications.DomainModel.Entities;

namespace MyNotifications.Database;

public class MyNotificationsDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
}