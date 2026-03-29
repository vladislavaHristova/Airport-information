using System;
using System.Linq;
using AirportInfo.Data.Entities;

namespace AirportInfo.Data;

public static class SeedData
{
    public static void Initialize(AirportDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Airports.Any())
        {
            return;
        }

        var airports = new Airport[]
        {
            new Airport { Code = "SOF", Name = "София", City = "София", Country = "България", TimeZone = "EET" },
            new Airport { Code = "LHR", Name = "Heathrow", City = "Лондон", Country = "UK", TimeZone = "GMT" },
            new Airport { Code = "CDG", Name = "Charles de Gaulle", City = "Париж", Country = "Франция", TimeZone = "CET" },
        };
        context.Airports.AddRange(airports);
        context.SaveChanges();

        var flights = new Flight[]
        {
            new Flight
            {
                FlightNumber = "FB437",
                Airline = "Bulgaria Air",
                DepartureAirportId = 1,
                ArrivalAirportId = 2,
                DepartureTime = DateTime.Today.AddHours(8).AddMinutes(30),
                ArrivalTime = DateTime.Today.AddHours(10).AddMinutes(45),
                Status = FlightStatus.OnTime,
                Gate = "A12",
                Terminal = 2
            },
            new Flight
            {
                FlightNumber = "AF1789",
                Airline = "Air France",
                DepartureAirportId = 1,
                ArrivalAirportId = 3,
                DepartureTime = DateTime.Today.AddHours(12).AddMinutes(15),
                ArrivalTime = DateTime.Today.AddHours(13).AddMinutes(45),
                Status = FlightStatus.Delayed,
                Gate = "B5",
                Terminal = 1
            }
        };
        context.Flights.AddRange(flights);
        context.SaveChanges();
    }
}