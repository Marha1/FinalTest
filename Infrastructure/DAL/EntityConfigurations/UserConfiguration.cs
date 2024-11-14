using FinalTestDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Buildings)
            .WithMany(b => b.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserBuilding",
                j => j.HasOne<Building>().WithMany().HasForeignKey("BuildingId"),
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
            );
    }
}