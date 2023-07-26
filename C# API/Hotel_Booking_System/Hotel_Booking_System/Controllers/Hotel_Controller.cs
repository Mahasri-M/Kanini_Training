using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories.Hotel_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Hotel_Controller : ControllerBase
    {
        private readonly IHotel hot;
        public Hotel_Controller(IHotel hot)
        {
            this.hot = hot;
        }
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return hot.GetAllHotel();
        }

        [HttpGet("{id}")]
        public Hotel GetById(int Hotel_Id)
        {
            return hot.GetHotelById(Hotel_Id);
        }

        [HttpPost]
        public Hotel PostHotel(Hotel hotel)
        {
            return hot.PostHotel(hotel);
        }
        [HttpPut("{id}")]
        public Hotel PutHotel(int Hotel_Id, Hotel hotel)
        {
            return hot.PutHotel(Hotel_Id, hotel);
        }
        [HttpDelete("{id}")]
        public Hotel DeleteHotel(int Hotel_Id)
        {
            return hot.DeleteHotel(Hotel_Id);
        }
        
    }
}
 
