using AirportInfo.Data;
using AirportInfo.Data.Entities;
using AirportInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingResponse = AirportInfo.Data.Entities.BookingResponse;

namespace AirportInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AirportDbContext _context;

        public BookingsController(AirportDbContext context)
        {
            _context = context;
        }

        // POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<BookingResponse>> CreateBooking(CreateBooking bookingDto)
        {
            var flight = await _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .FirstOrDefaultAsync(f => f.Id == bookingDto.FlightId);

            if (flight == null)
            {
                return NotFound("Flight not found");
            }

            var booking = new CreateBooking
            {
                FlightId = bookingDto.FlightId,
                PassengerName = bookingDto.PassengerName,
                PassengerEmail = bookingDto.PassengerEmail,
                BookingDate = DateTime.UtcNow,
                Status = BookingStatus.Confirmed
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            var response = new BookingResponse
            {
                Id = booking.Id,
                FlightId = flight.Id,
                FlightNumber = flight.FlightNumber,
                Airline = flight.Airline,
                DepartureAirport = flight.DepartureAirport.Code,
                ArrivalAirport = flight.ArrivalAirport.Code,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                PassengerName = booking.PassengerName,
                PassengerEmail = booking.PassengerEmail,
                BookingDate = booking.BookingDate,
                Status = booking.Status.ToString()
            };

            return Ok(response);
        }
    }
}