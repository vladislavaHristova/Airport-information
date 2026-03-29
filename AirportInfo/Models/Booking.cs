namespace AirportInfo.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}