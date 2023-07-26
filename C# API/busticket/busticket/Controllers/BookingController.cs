using busticket.Models;
using busticket.Services.BookRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace busticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBooking _book;
        public BookingController(IBooking book)
        {
            _book = book;
        }
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return _book.GetAllBookings();
        }

        [HttpGet("{id}")]
        public Booking GetById(int id)
        {
            return _book.GetBookingsById(id);
        }
        [HttpPost]
        public async Task<ActionResult<List<Booking>>> AddBookingDetails(Booking book)
        {
            var bookings = await _book.AddBookingDetails(book);
            return Ok(bookings);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Booking>?>> UpdateBookingDetailsById(int id, Booking book)
        {
            var bookings = await _book.UpdateBookingDetailsById(id, book);
            if (bookings is null)
            {
                return NotFound("Booking id not matching");
            }
            return Ok(bookings);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Booking>>> DeleteBookingDetailsById(int id)
        {
            var bookings = await _book.DeleteBookingDetailsById(id);
            if (bookings is null)
            {
                return NotFound("Bookingid not matching");
            }
            return Ok(bookings);
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel model)
        {
            bool emailSent = await _book.SendEmailAsync(model.RecipientEmail, model.Subject, model.EmailContent);

            if (emailSent)
            {
                return Ok("Email sent successfully");
            }
            else
            {
                return StatusCode(500, "Failed to send email");
            }
        }


    }
    public class EmailModel
    {
        public string RecipientEmail { get; set; }
        public string Subject { get; set; }
        public string EmailContent { get; set; }
    }
}
