using Microsoft.AspNetCore.SignalR;

public class Fligt
{
    public int Id {get; set;}
    public string FlightNumber {get;set;}
    public string AircraftCompany {get;set;}
    public string Destination {get;set;}
    public DateTime DepartureTime {get; set;}
    public DateTime ArrivalTime {get;set;}
    public string Status {get;set;} 
        //being on time, delayed or canceled
    public string Gate {get;set;}
    public int Terminal {get;set;}
}
