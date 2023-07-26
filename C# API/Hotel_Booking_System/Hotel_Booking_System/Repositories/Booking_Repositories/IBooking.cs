using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories.Booking_Repositories
{
    public interface IBooking
    {
        public IEnumerable<Booking> GetAllBookings();
        public Booking GetBookingsById(int Booking_Id);
        public Booking PostBooking(Booking Booking);
        public Booking PutBooking(int Booking_Id, Booking Booking);
        public Booking DeleteBooking(int Booking_Id);
    }
}
