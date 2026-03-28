namespace AirportInfo.Models
{
    public class FlightViewModel
    {
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string FromCity { get; set; }
        public string FromCode { get; set; }
        public string ToCity { get; set; }
        public string ToCode { get; set; }
        public string DepartureTimeDisplay { get; set; }
        public string ArrivalTimeDisplay { get; set; }
        public string StatusDisplay { get; set; }
        public string GateDisplay { get; set; }
        public int Terminal { get; set; }
    }
}