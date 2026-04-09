using AirportInfo.Data;
using AirportInfo.Data.Entities;
using Microsoft.EntityFrameworkCore;

//connection with DB
var options = new DbContextOptionsBuilder<AirportDbContext>()
    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AirportInfoDB;Trusted_Connection=True;")
    .Options;

var db = new AirportDbContext(options);

while (true)
{
    Console.WriteLine("AIRPORT");
    Console.WriteLine("1 - Look  for flights");
    Console.WriteLine("2 - Book flight");
    Console.WriteLine("3 - Exit");
    Console.Write("Choose: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        var list = db.Flights.ToList();
        Console.WriteLine("FLIGHTS");
        foreach (var f in list)
        {
            Console.WriteLine(f.FlightNumber + "-" + f.Airline + "-" + f.DepartureTime.ToString("HH:mm"));
        }
        Console.WriteLine("Press a key...");
        Console.ReadKey();
    }
    else if (choice == "2")
    {
        var list = db.Flights.ToList();
        Console.WriteLine("CHOOSE A FLIGHT");
        foreach (var f in list)
        {
            Console.WriteLine(f.Id + "-" + f.FlightNumber);
        }
        Console.Write("Number: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Booked flight" + " " + id + " " + "for" + " " + name);
        Console.ReadKey();
    }
    else if (choice == "3")
    {
        break;
    }

}