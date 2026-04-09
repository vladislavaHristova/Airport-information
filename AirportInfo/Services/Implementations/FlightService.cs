using Microsoft.EntityFrameworkCore;
using AirportInfo.Data;
using AirportInfo.Data.Entities;
using AirportInfo.Services.Interfaces;
using System.Linq;

namespace AirportInfo.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly AirportDbContext _context;

        public FlightService(AirportDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .FirstOrDefault(f => f.Id == id);
        }

        public Flight AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
            return flight;
        }

        public Flight UpdateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            _context.SaveChanges();
            return flight;
        }

        public bool DeleteFlight(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null)
                return false;

            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return true;
        }
    }
}