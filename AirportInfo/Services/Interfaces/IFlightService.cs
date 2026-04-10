using AirportInfo.Data.Entities;

namespace AirportInfo.Services.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetAllFlights();
        IEnumerable<Flight> SearchFlights(string destination);
        Flight GetFlightById(int id);
        Flight AddFlight(Flight flight);
        Flight UpdateFlight(Flight flight);
        bool DeleteFlight(int id);
    }
}