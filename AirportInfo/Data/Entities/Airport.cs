using System.Collections.Generic;

namespace AirportInfo.Data.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;

        public virtual ICollection<Flight> Departures { get; set; } = new List<Flight>();
        public virtual ICollection<Flight> Arrivals { get; set; } = new List<Flight>();
    }
}