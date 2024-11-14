using FinalTestDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.OwnsOne(s => s.GeoLocation, geo =>
        {
            geo.Property(g => g.X).IsRequired();
            geo.Property(g => g.Y).IsRequired();
        });

        builder.HasMany(s => s.Data)
            .WithOne(d => d.Sensor)
            .HasForeignKey(d => d.SensorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}