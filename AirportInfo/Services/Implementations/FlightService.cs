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

        //returns all flights from the db
        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .ToList();
        }

        //searches flights by id
        public Flight GetFlightById(int id)
        {
            return _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .FirstOrDefault(f => f.Id == id);
        }


        //adds n ew flight to the db
        public Flight AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
            return flight;
        }


        // updates existing flight
        public Flight UpdateFlight(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            _context.SaveChanges();
            return flight;
        }


        //deletes a flight from the db
        public bool DeleteFlight(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null)
                return false;

            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return true;
        }

        //searches flights by destinations
        public IEnumerable<Flight> SearchFlights(string destination)
        {
            if (string.IsNullOrEmpty(destination))
                return GetAllFlights();

            return _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f=> f.ArrivalAirport)
                .Where(f=> f.ArrivalAirport.City.Contains(destination)|| f.ArrivalAirport.Code.Contains(destination))
                .ToList();
        }
    }
}