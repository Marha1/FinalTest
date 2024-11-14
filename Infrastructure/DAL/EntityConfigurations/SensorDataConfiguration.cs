using FinalTestDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
{
    public void Configure(EntityTypeBuilder<SensorData> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Timestamp)
            .IsRequired();

        builder.Property(d => d.Temperature)
            .IsRequired();

        builder.Property(d => d.Humidity)
            .IsRequired();

        builder.Property(d => d.BatteryLevel)
            .IsRequired();
    }
}
