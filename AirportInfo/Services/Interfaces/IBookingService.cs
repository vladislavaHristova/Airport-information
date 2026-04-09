using AirportInfo.Models;

namespace AirportInfo.Services.Interfaces
{
    public interface IBookingService
    {
        BookingResponse CreateBooking(CreateBookingDto bookingDto);
    }
}