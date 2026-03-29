using Microsoft.AspNetCore.Mvc;
using AirportInfo.Services.Interfaces;
using AirportInfo.Models;
using AirportInfo.Data.Entities;

namespace AirportInfo.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllFlightsAsync();

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

        public async Task<IActionResult> Book(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);

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
                PassengerName = string.Empty,
                PassengerEmail = string.Empty,
                PassengerPhone = string.Empty
            };

            return View(bookingViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = $"Flight {model.FlightNumber} successfully booked for {model.PassengerName}!";
                return RedirectToAction(nameof(Index));
            }

            var flight = await _flightService.GetFlightByIdAsync(model.FlightId);
            if (flight != null)
            {
                model.FlightNumber = flight.FlightNumber;
                model.Airline = flight.Airline;
                model.FromCity = flight.DepartureAirport?.City ?? "Unknown";
                model.FromCode = flight.DepartureAirport?.Code ?? "???";
                model.ToCity = flight.ArrivalAirport?.City ?? "Unknown";
                model.ToCode = flight.ArrivalAirport?.Code ?? "???";
                model.DepartureTime = flight.DepartureTime;
            }

            return View(model);
        }
    }
}