using FinalTestDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext:DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<SensorData> SensorData => Set<SensorData>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
    
}