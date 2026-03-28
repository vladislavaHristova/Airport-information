using AirportInfo.Data.Entities;

namespace AirportInfo.Services.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int id);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<Flight> UpdateFlightAsync(Flight flight);
        Task<bool> DeleteFlightAsync(int id);
    }
}