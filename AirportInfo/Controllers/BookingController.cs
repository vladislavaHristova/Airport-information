using Microsoft.AspNetCore.Mvc;
using AirportInfo.Services.Interfaces;
using AirportInfo.Models;

namespace AirportInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;  // ← Service, не директен DbContext!

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public ActionResult<BookingResponse> CreateBooking(CreateBookingDto bookingDto)
        {
            var result = _bookingService.CreateBooking(bookingDto);  // ← само вика Service

            if (result == null)
            {
                return NotFound("Flight not found");
            }

            return Ok(result);
        }
    }
}