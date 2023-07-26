using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories.Booking_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Booking_Controller : ControllerBase
    {
        private readonly IBooking book;
        public Booking_Controller(IBooking book)
        {
            this.book = book;
        }
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return book.GetAllBookings();
        }

        [HttpGet("{id}")]
        public Booking GetById(int id)
        {
            return book.GetBookingsById(id);
        }

        [HttpPost]
        public Booking PostBooking(Booking Booking)
        {
            return book.PostBooking(Booking);
        }
        [HttpPut("{id}")]
        public Booking PutBooking(int id, Booking Booking)
        {
            return book.PutBooking(id, Booking);
        }
        [HttpDelete("{id}")]
        public Booking DeleteBooking(int id)
        {
            return book.DeleteBooking(id);
        }
    }
}
