namespace AirportInfo.Models
{

    //model for showing flights in view
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string FromCity { get; set; } = string.Empty;
        public string FromCode { get; set; } = string.Empty;
        public string ToCity { get; set; } = string.Empty;
        public string ToCode { get; set; } = string.Empty;
        public string DepartureTimeDisplay { get; set; } = string.Empty;
        public string ArrivalTimeDisplay { get; set; } = string.Empty;
        public string StatusDisplay { get; set; } = string.Empty;
        public string GateDisplay { get; set; } = string.Empty;
        public int Terminal { get; set; }
    }
}