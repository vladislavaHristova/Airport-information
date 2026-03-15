public class Flight
{
     public string FlightNumber { get; set; }
     public string Airline { get; set; }
    public string FromCity { get; set; }      // София
    public string FromCode { get; set; }       // SOF
    public string ToCity { get; set; }         // Лондон
    public string ToCode { get; set; }         // LHR
    public string DepartureTimeDisplay { get; set; }  // "14:30"
    public string ArrivalTimeDisplay { get; set; }     // "16:45"
    public string StatusDisplay { get; set; }           // "On Time"
    public string GateDisplay { get; set; }              // "A12"
    public int Terminal { get; set; }
}
