using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNotifications.DomainModel.Entities;

namespace MyNotifications.Database.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Content)
            .IsRequired();
        
        builder.Property(x => x.Created)
            .IsRequired();
        
        builder.Property(x => x.Send)
            .IsRequired(false);
    }
}