using AirportInfo.Data;
using AirportInfo.Data.Entity;
using AirportInfo.Services.Interfaces;

namespace AirportInfo.Services.Inplementations;

public class FlightService : IFlightService
{
    private readonly AirportDbContext _context;
    public FlightService(AirportDbContext context)
    {}
}