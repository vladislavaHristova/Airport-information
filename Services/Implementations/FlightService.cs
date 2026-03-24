using AirportInfo.Data;
using AirportInfo.Data.Entity;
using AirportInfo.Services.Interfaces;

namespace AirportInfo.Services.Inplementations;

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
    public async Task<Flight> GetFlightByIdAsync(int id)
    {
        return await _context.Flights 
            .Include(f => f.DepartureAirport)
            .Include(f => f.ArrivalAirport)
            .FirstOrDefault (f => f.Id == id);
    }
    public async Task<Flight> AddFlightByAsync(Flight flight)
    {
        _context.Flight.Add(flight);
        await _context.SaveChangeAsync();
        return flight;
    }
    public async Task<Flight> UpdateFlightAsync(Flight flight)
    {
        _context.Entry(flight).State = EntityState.Modifier;
        await _context.SaveChangeAsync();
        return flight;
    }
    public async Task<bool> DeleteFlightAsync(int id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight == null)
            return false;
        
        _context.Flights.Remove(flight);
        await _context.SaveChangeAsync();
        return true;
    }
}