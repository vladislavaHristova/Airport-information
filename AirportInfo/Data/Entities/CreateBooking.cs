using AirportInfo.Models;
using System;

namespace AirportInfo.Data.Entities
{
    public class CreateBooking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; } = string.Empty;
        public string PassengerEmail { get; set; } = string.Empty;
        public string PassengerPhone { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public BookingStatus Status { get; set; }

        public virtual Flight Flight { get; set; } = null!;
    }
}