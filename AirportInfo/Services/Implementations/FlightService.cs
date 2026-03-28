using Microsoft.EntityFrameworkCore;
using AirportInfo.Data;
using AirportInfo.Data.Entities;
using AirportInfo.Services.Interfaces;

namespace AirportInfo.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly AirportDbContext _context;
        
        public FlightService(AirportDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .ToListAsync();
        }
        
        // ДОБАВИ ТЕЗИ МЕТОДИ:
        
        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            return await _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        
        public async Task<Flight> AddFlightAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }
        
        public async Task<Flight> UpdateFlightAsync(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flight;
        }
        
        public async Task<bool> DeleteFlightAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
                return false;
                
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}