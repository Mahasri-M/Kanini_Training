using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories.Room_Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Room_Controller : ControllerBase
    {
        private readonly IRoom room;
        public Room_Controller(IRoom room)
        {
            this.room = room;
        }
        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return room.GetAllRoom();
        }

        [HttpGet("{id}")]
        public Room GetById(int id)
        {
            return room.GetRoomById(id);
        }

        [HttpPost]
        public Room PostRoom(Room Room)
        {
            return room.PostRoom(Room);
        }
        [HttpPut("{id}")]
        public Room PutRoom(int id, Room Room)
        {
            return room.PutRoom(id, Room);
        }
        [HttpDelete("{id}")]
        public Room DeleteRoom(int id)
        {
            return room.DeleteRoom(id);
        }

    }
}
