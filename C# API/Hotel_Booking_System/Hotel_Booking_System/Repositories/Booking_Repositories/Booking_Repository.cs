using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.Booking_Repositories
{
    public class Booking_Repository:IBooking
    {
        private readonly HotelContext _BookingContext;
        public Booking_Repository(HotelContext context)
        {
            _BookingContext = context;
        }
        //GetAllBooking
        public IEnumerable<Booking> GetAllBookings()
        {
            return _BookingContext.Bookings.ToList();
        }
        //GetBookingById
        public Booking GetBookingsById(int Booking_Id)
        {
            return _BookingContext.Bookings.FirstOrDefault(x => x.Book_Id == Booking_Id);
        }
        //PostBooking
        public Booking PostBooking(Booking Booking)
        {
            var book = _BookingContext.Hotels.Find(Booking.Hotel.Hotel_Id);
            Booking.Hotel = book;
            _BookingContext.Add(Booking);
            _BookingContext.SaveChanges();
            return Booking;
        }
        //PutBooking
        public Booking PutBooking(int Booking_Id, Booking Booking)
        {
            var book = _BookingContext.Hotels.Find(Booking.Hotel.Hotel_Id);
            Booking.Hotel = book;
            _BookingContext.Entry(Booking).State = EntityState.Modified;
            _BookingContext.SaveChangesAsync();
            return Booking;
        }
        //DeleteBooking
        public Booking DeleteBooking(int Booking_Id)
        {
            var book = _BookingContext.Bookings.Find(Booking_Id);
            _BookingContext.Bookings.Remove(book);
            _BookingContext.SaveChanges();
            return book;
        }
    }
}
