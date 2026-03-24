using Microisoft.AspNetCore.Mvc;
using AirportInfo.Services.Interfaces;
using AirportInfo.Models;
using AirportInfo.Datya.Entity;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.ComponentModel.Design;

namespace AirportInfo.Controllers;

public class FlightsController : Controllers
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
            FlightNumber = f.FlightNumber,
            Airline = f.Airline,
            FromCity =f.DepartureAirport?.City??"Unknown",
            FromCode =f.DepartureAirport?.Code??"???",
            ToCity = f.ArrivalAirport?.City??"Unknown",
            ToCode = f.ArrivalAirport?.Code??"???",
            DepartureTimeDisplay = f.DepartureTime.ToString ("HH:mm"),
            ArrivalTimeDisplay = f.ArrivalTime.ToString("HH:mm"),
            StatusDisplay = f.Status.ToString(),
            GateDisplay = f.Gate,
            Terminal = f.Terminal
        }).ToList();

        return View(viewModels);
    }
}