using Microsoft.EntityFrameworkCore;
using AirportInfo.Data.Entities;

namespace AirportInfo.Data
{
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options)
            : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CreateBooking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany(a => a.Departures)
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalAirport)
                .WithMany(a => a.Arrivals)
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CreateBooking>()
                .HasOne(b => b.Flight)
                .WithMany()
                .HasForeignKey(b => b.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}