using Microsoft.EntityFrameworkCore;
using PuebaASP.Models;

namespace PruebaASP.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.AirportOrigin)
                .WithMany()
                .HasForeignKey(f => f.AirportOriginId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.AirportDestination)
                .WithMany()
                .HasForeignKey(f => f.AirportDestinationId);

            modelBuilder.Entity<Flight>()
                .HasOne(p => p.Plane)
                .WithMany()
                .HasForeignKey(p => p.PlaneId);

            modelBuilder.Entity<Flight>()
                .HasOne(c => c.Crew)
                .WithMany()
                .HasForeignKey(c => c.CrewId);
        }
    }
}

