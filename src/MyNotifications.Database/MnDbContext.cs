using Microsoft.EntityFrameworkCore;
using MyNotifications.Database.Configurations;
using MyNotifications.DomainModel.Entities;

namespace MyNotifications.Database;

public class MnDbContext : DbContext
{
    public DbSet<Notification> Notifications { get; set; }
    
    public MnDbContext(DbContextOptions<MnDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}