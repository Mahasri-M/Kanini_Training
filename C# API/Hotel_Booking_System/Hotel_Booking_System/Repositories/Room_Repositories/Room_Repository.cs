using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.Room_Repositories
{
    public class Room_Repository:IRoom
    {
        private readonly HotelContext _roomContext;
        public Room_Repository(HotelContext context)
        {
            _roomContext = context;
        }
        //GetAllRooms
        public IEnumerable<Room> GetAllRoom()
        {
            return _roomContext.Rooms.ToList();
        }
        //GetRoomById
        public Room GetRoomById(int Room_Id)
        {
            return _roomContext.Rooms.FirstOrDefault(x => x.Room_Id == Room_Id);
        }
        //PostRoom
        public Room PostRoom(Room room)
        {
            var v_room = _roomContext.Hotels.Find(room.Hotel.Hotel_Id);
            room.Hotel = v_room;
            _roomContext.Add(room);
            _roomContext.SaveChanges();
            return room;
        }
        //PutRoom
        public Room PutRoom(int Room_Id, Room room)
        {
            var v_room = _roomContext.Hotels.Find(room.Hotel.Hotel_Id);
            room.Hotel = v_room;
            _roomContext.Entry(room).State = EntityState.Modified;
            _roomContext.SaveChangesAsync();
            return room;
        }
        //DeleteRoom
        public Room DeleteRoom(int Room_Id)
        {
            var v_room = _roomContext.Rooms.Find(Room_Id);
            _roomContext.Rooms.Remove(v_room);
            _roomContext.SaveChanges();
            return v_room;
        }
    }
}
