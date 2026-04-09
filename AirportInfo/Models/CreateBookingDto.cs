namespace AirportInfo.Models
{
    public class CreateBookingDto
    {
        public int FlightId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
    }
}