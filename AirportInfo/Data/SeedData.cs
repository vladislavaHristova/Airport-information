using System;
using System.Linq;
using AirportInfo.Data.Entities;

namespace AirportInfo.Data;

public static class SeedData
{
    public static void Initialize(AirportDbContext context)
    {
        context.Database.EnsureCreated();  // ← Database, не DataBase
        
        if (context.Airports.Any())  // ← Airports, не Airport
        {
            return;
        }
        
        var airports = new Airport[]
        {
            new Airport { Code = "SOF", Name = "София", City = "София", Country = "България" },
            new Airport { Code = "LHR", Name = "Heathrow", City = "Лондон", Country = "UK" },
            new Airport { Code = "CDG", Name = "Charles de Gaulle", City = "Париж", Country = "Франция" },
        };
        context.Airports.AddRange(airports);
        context.SaveChanges();

        var flights = new Flight[]
        {
            new Flight
            {
                FlightNumber = "FB437",
                Airline = "WizzAir",
                DepartureAirportId = 1,
                ArrivalAirportId = 2,
                DepartureTime = DateTime.Today.AddHours(8).AddMinutes(30),
                ArrivalTime = DateTime.Today.AddHours(10).AddMinutes(45),
                Status = FlightStatus.Delayed,
                Gate = "A12",
                Terminal = 2
            },
            new Flight
            {
                FlightNumber = "AF1789",
                Airline = "FranceAir",
                DepartureAirportId = 1,
                ArrivalAirportId = 3,
                DepartureTime = DateTime.Today.AddHours(12).AddMinutes(15),
                ArrivalTime = DateTime.Today.AddHours(13).AddMinutes(45),
                Status = FlightStatus.OnTime,
                Gate = "B5",
                Terminal = 1
            }
        };
        context.Flights.AddRange(flights);
        context.SaveChanges();
    }
}