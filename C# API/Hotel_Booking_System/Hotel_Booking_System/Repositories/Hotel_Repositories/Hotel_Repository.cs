using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.Hotel_Repositories
{
    public class Hotel_Repository:IHotel
    {
        private readonly HotelContext _hotelContext;
        public Hotel_Repository(HotelContext con)
        {
            _hotelContext = con;
        }
        //GetAllHotel
        public IEnumerable<Hotel> GetAllHotel()
        {
            return _hotelContext.Hotels.Include(x => x.Rooms).ToList();
        }
        //GetHotelById
        public Hotel GetHotelById(int HotelId)
        {
            return _hotelContext.Hotels.FirstOrDefault(x => x.Hotel_Id == HotelId);
        }
        //PostHotel
        public Hotel PostHotel(Hotel hotel)
        {
            _hotelContext.Hotels.Add(hotel);
            _hotelContext.SaveChanges();
            return hotel;
        }
        //PutHotel
        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            _hotelContext.Entry(hotel).State = EntityState.Modified;
            _hotelContext.SaveChangesAsync();
            return hotel;
        }
        //DeleteHotel
        public Hotel DeleteHotel(int HotelId)
        {
            var hotel = _hotelContext.Hotels.Find(HotelId);
            _hotelContext.Hotels.Remove(hotel);
            _hotelContext.SaveChanges();

            return hotel;
        }

       
    }
}
