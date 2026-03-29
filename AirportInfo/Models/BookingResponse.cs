namespace AirportInfo.Models
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string DepartureAirport { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
