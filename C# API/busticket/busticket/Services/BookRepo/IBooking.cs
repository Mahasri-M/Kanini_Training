using busticket.Models;

namespace busticket.Services.BookRepo
{
    public interface IBooking
    {
        public IEnumerable<Booking> GetAllBookings();
        public Booking GetBookingsById(int Booking_Id);
        Task<bool> SendEmailAsync(string recipientEmail, string subject, string emailContent);
        Task<List<Booking>> AddBookingDetails(Booking book);
        Task<List<Booking>?> UpdateBookingDetailsById(int id, Booking book);
        Task<List<Booking>?> DeleteBookingDetailsById(int id);
    }
}
