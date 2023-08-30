using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telemetry>()
                .HasOne(i => i.Device)
                .WithMany(d => d.Telemetries)
                .HasForeignKey(i => i.DeviceId);

            modelBuilder.Entity<Device>()
                .HasData(new Device()
                {
                    Id = 1,
                    Name = "FirstDevice"
                });

            modelBuilder.Entity<Device>()
                .HasMany(i => i.Telemetries)
                .WithOne(d => d.Device)
                .HasForeignKey(i => i.DeviceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
