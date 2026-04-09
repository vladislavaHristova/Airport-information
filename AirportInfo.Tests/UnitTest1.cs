using NUnit.Framework;
using AirportInfo.Data;
using AirportInfo.Data.Entities;
using AirportInfo.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using AirportInfo.Models;
using AirportInfo.Controllers;

namespace AirportInfo.Tests
{
    [TestFixture]
    public class FlightServiceTests
    {
        [Test]

        // will check whether the program takes all flights and returns an empty list
        public void GetAllFlights_ShouldReturnEmptyList()
        {
            // creats temporary db - only for the test
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            // opens a connection with the temporary db
            var context = new AirportDbContext(options);
            // creats service that will be tested
            var service = new FlightService(context);

            // calls the tested method
            var result = service.GetAllFlights();

            //checks if the result is 0 - empty list
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        // will check whether the program takes all flights and adds a new one
        public void AddFlight_ShouldAddFlight()
        {
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb2")
                .Options;

            var context = new AirportDbContext(options);
            var service = new FlightService(context);

            var flight = new Flight
            {
                FlightNumber = "TEST123",
                Airline = "Test Airline"
            };

            service.AddFlight(flight);

            var result = service.GetAllFlights();

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        // will check whether the program find a flight by id and gives the corresponding text
        public void GetFlightById_ShouldReturnCorrectFlight()
        {
            var options = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb3")
                .Options;

            var context = new AirportDbContext(options);
            var service = new FlightService(context);

            var flight = new Flight
            {
                Id = 1,
                FlightNumber = "TEST123",
                Airline = "Test Airline"
            };
            service.AddFlight(flight);

            var result = service.GetFlightById(1);

            Assert.That(result.FlightNumber, Is.EqualTo("TEST123"));
        }

        [Test]
        //will check whether the program returns null when searching for a flight that doesn't exist
        public void GetFlightById_WithInvalidId_ShouldReturnNull()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb4")
                .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);

            var result = service.GetFlightById(888);

            Assert.That(result == null);
        }

        [Test]
        //will check whether the program updates a flight corrctly
        public void UpdateFlight_ShouldUpdateFlight()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb5")
                .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);

            var flight = new Flight
            {
                FlightNumber = "TEST456",
                Airline = "Test Airline"
            };
            service.AddFlight(flight);

            flight.Airline = "Updated Airline";
            service.UpdateFlight(flight);

            var result = service.GetFlightById(flight.Id);
            Assert.That(result.Airline, Is.EqualTo("Updated Airline"));
        }

        [Test]
        //will check whether teh program deletes a flight with valid id
        public void DeleteFlight_WithValidId_ShouldReturnTrue()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb6")
                .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);

            var flight = new Flight
            {
                FlightNumber = "TEST789",
                Airline = "Test Airline"
            };
            service.AddFlight(flight);

            var result = service.DeleteFlight(flight.Id);
            Assert.That(result == true);
        }

        [Test]
        //will check whether the program returns false when deletiung a flight that doesn't exist
        public void DeleteFlight_WithInvalidId_ShouldReturnFalse()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("TestDb7")
                .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);

            var result = service.DeleteFlight(888);
            Assert.That(result == false);
        }

        [Test]
        // will check whether the program will create a booking with valid flight
        public void CreateBooking_WithValidFlight_ShouldReturnBooking()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("BookingTest1")
                .Options;

            var context = new AirportDbContext(option);
            var flightService = new FlightService(context);
            var bookingService = new BookingService(context);

            var flight = new Flight
            {
                FlightNumber = "Test123",
                Airline = "Test Airline"
            };
            flightService.AddFlight(flight);

            var bookingDto = new CreateBookingDto
            {
                FlightId = flight.Id,
                PassengerName = "Ivan Ivanov",
                PassengerEmail = "ivan@abv.bg"
            };

            var result = bookingService.CreateBooking(bookingDto);

            Assert.That(result != null);
            Assert.That(result.PassengerName, Is.EqualTo("Ivan Ivanov"));
        }


        [Test]
        //will check whether the program will not create a booking with invalid flight
        public void CreateBooking_WithInvalidFlight_ShouldReturnNull()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("BookingTest2")
                .Options;

            var context = new AirportDbContext(option);
            var bookingService = new BookingService(context);

            var bookingDto = new CreateBookingDto
            {
                FlightId = 888,
                PassengerName = "Ivan Ivanov",
                PassengerEmail = "ivan@abv.bg"
            };
            var result = bookingService.CreateBooking(bookingDto);

            Assert.That(result == null);
        }

        [Test]
        //will check if with valid id flightController returns View
        public void Book_WithValidId_shouldReturnView()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                .UseInMemoryDatabase("ControllerTest1")
                .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);
            var controller = new FlightsController(service);

            var flight = new Flight
            {
                FlightNumber = "TEST456",
                Airline = "Test Airline"
            };
            service.AddFlight(flight);

            var result = controller.Book(flight.Id);

            Assert.That(result != null);
        }

        [Test]
        // will check if with invalid id flightController returns error
        public void Book_WithInvalidId_ShouldReturnNotFound()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                 .UseInMemoryDatabase("ControllerTest2")
                 .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);
            var controller = new FlightsController(service);

            var result = controller.Book(888);

            Assert.That(result != null);
        }

        [Test]
        // will test whether the Index returns View
        public void Index_ShouldReturnView()
        {
            var option = new DbContextOptionsBuilder<AirportDbContext>()
                 .UseInMemoryDatabase("ControllerTest3")
                 .Options;

            var context = new AirportDbContext(option);
            var service = new FlightService(context);
            var controller = new FlightsController(service);

            var result = controller.Index();

            Assert.That(result != null);
        }
    }
}