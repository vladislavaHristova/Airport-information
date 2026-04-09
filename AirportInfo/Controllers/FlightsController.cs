using Microsoft.AspNetCore.Mvc;
using AirportInfo.Services.Interfaces;
using AirportInfo.Models;
using AirportInfo.Data.Entities;
using System.Linq;

namespace AirportInfo.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        // shows list with all flights
        public IActionResult Index()
        {
            var flights = _flightService.GetAllFlights();

            var viewModels = flights.Select(f => new FlightViewModel
            {
                Id = f.Id,
                FlightNumber = f.FlightNumber,
                Airline = f.Airline,
                FromCity = f.DepartureAirport?.City ?? "Unknown",
                FromCode = f.DepartureAirport?.Code ?? "???",
                ToCity = f.ArrivalAirport?.City ?? "Unknown",
                ToCode = f.ArrivalAirport?.Code ?? "???",
                DepartureTimeDisplay = f.DepartureTime.ToString("HH:mm"),
                ArrivalTimeDisplay = f.ArrivalTime.ToString("HH:mm"),
                StatusDisplay = f.Status.ToString(),
                GateDisplay = f.Gate ?? "TBA",
                Terminal = f.Terminal
            }).ToList();

            return View(viewModels);
        }

        // shos a form for booking a flight
        public IActionResult Book(int id)
        {
            var flight = _flightService.GetFlightById(id);

            if (flight == null)
            {
                return NotFound();
            }

            var bookingViewModel = new BookingViewModel
            {
                FlightId = flight.Id,
                FlightNumber = flight.FlightNumber,
                Airline = flight.Airline,
                FromCity = flight.DepartureAirport?.City ?? "Unknown",
                FromCode = flight.DepartureAirport?.Code ?? "???",
                ToCity = flight.ArrivalAirport?.City ?? "Unknown",
                ToCode = flight.ArrivalAirport?.Code ?? "???",
                DepartureTime = flight.DepartureTime,
                Price = 150.00m,
                PassengerName = "",
                PassengerEmail = "",
                PassengerPhone = ""
            };

            return View(bookingViewModel);
        }


        // saves the booking in db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Flight " + model.FlightNumber + " booked for " + model.PassengerName;
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}