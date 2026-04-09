using AirportInfo.Data;
using AirportInfo.Data.Entities;
using AirportInfo.Models;
using AirportInfo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirportInfo.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly AirportDbContext _context;

        public BookingService(AirportDbContext context)
        {
            _context = context;
        }

        //creates new booking for a flight
        public Data.Entities.BookingResponse CreateBooking(CreateBookingDto bookingDto)
        {
            var flight = _context.Flights
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .FirstOrDefault(f => f.Id == bookingDto.FlightId);

            //if the flight does not exist it returns null
            if (flight == null)
            {
                return null;
            }

            var booking = new CreateBooking
            {
                FlightId = bookingDto.FlightId,
                PassengerName = bookingDto.PassengerName,
                PassengerEmail = bookingDto.PassengerEmail,
                BookingDate = DateTime.UtcNow,
                Status = BookingStatus.Confirmed
            };

            //saves the booking in db
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            //returns information about the booking
            return new Data.Entities.BookingResponse
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
        }

        //creates new reservation
        Models.BookingResponse IBookingService.CreateBooking(CreateBookingDto bookingDto)
        {
            throw new NotImplementedException();
        }
    }
}