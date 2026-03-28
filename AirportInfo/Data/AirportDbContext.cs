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
    }
}