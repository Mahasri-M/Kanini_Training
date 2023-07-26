using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories.Room_Repositories
{
    public interface IRoom
    {
        public IEnumerable<Room> GetAllRoom();
        public Room GetRoomById(int Room_Id);
        public Room PostRoom(Room room);
        public Room PutRoom(int Room_Id, Room room);
        public Room DeleteRoom(int Room_Id);
    }
}
