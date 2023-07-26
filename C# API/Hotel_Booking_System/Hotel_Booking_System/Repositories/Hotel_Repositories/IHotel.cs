using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories.Hotel_Repositories
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetAllHotel();
        public Hotel GetHotelById(int Hotel_Id);
        public Hotel PostHotel(Hotel hotel);
        public Hotel PutHotel(int Hotel_Id, Hotel hotel);
        public Hotel DeleteHotel(int Hotel_Id);
        
    }
}
