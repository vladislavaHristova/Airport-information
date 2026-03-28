using System;

namespace AirportInfo.Data.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public FlightStatus Status { get; set; }
        public string Gate { get; set; } = string.Empty;
        public int Terminal { get; set; }
        
        // външни ключове
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        // навигация
        public virtual Airport DepartureAirport { get; set; } = null!;
        public virtual Airport ArrivalAirport { get; set; } = null!;
    }
    
    public enum FlightStatus
    {
        OnTime,
        Delayed,
        Cancelled,
        Boarding,
        Arrived
    }
}