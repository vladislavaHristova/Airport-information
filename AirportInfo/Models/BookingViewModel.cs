using System.ComponentModel.DataAnnotations;

namespace AirportInfo.Models
{
    public class BookingViewModel
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string FromCity { get; set; } = string.Empty;
        public string FromCode { get; set; } = string.Empty;
        public string ToCity { get; set; } = string.Empty;
        public string ToCode { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пълното име е задължително")]
        [Display(Name = "Пълно име")]
        [StringLength(100, MinimumLength = 2)]
        public string PassengerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Имейлът е задължителен")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес")]
        [Display(Name = "Имейл")]
        public string PassengerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефонът е задължителен")]
        [Phone(ErrorMessage = "Невалиден телефонен номер")]
        [Display(Name = "Телефон")]
        public string PassengerPhone { get; set; } = string.Empty;

        public string DepartureTimeDisplay => DepartureTime.ToString("dd.MM.yyyy HH:mm");
        public string Route => $"{FromCity} ({FromCode}) → {ToCity} ({ToCode})";
    }
}