using busticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace busticket.Services.BookRepo
{
    public class Book_service:IBooking
    {
        

        private readonly BusContext _BookingContext;
        public Book_service(BusContext context)
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
            return _BookingContext.Bookings.FirstOrDefault(x => x.BookingId == Booking_Id);
        }

        //PostBooking
        public async Task<List<Booking>> AddBookingDetails(Booking book)
        {
            _BookingContext.Bookings.Add(book);
            await _BookingContext.SaveChangesAsync();

            return await _BookingContext.Bookings.ToListAsync();
        }
        //Put
        public async Task<List<Booking>?> UpdateBookingDetailsById(int id, Booking book)
        {
            var booking = await _BookingContext.Bookings.FindAsync(id);
            if (booking is null)
            {
                return null;
            }
            booking.Passenger_Name=book.Passenger_Name;
            booking.Email=book.Email;
            booking.Age=book.Age;
            booking.Mobile=book.Mobile;
            booking.Gender=book.Gender;
           
            await _BookingContext.SaveChangesAsync();
            return await _BookingContext.Bookings.ToListAsync();
        }
        //Delete
        public async Task<List<Booking>?> DeleteBookingDetailsById(int id)
        {
            var booking = await _BookingContext.Bookings.FindAsync(id);
            if (booking is null)
            {
                return null;
            }
            _BookingContext.Remove(booking);
            await _BookingContext.SaveChangesAsync();
            return await _BookingContext.Bookings.ToListAsync();
        }

      public async Task<bool> SendEmailAsync(string recipientEmail, string subject, string emailContent)
        {
            try
            {
                // Configure SMTP client
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("Mahasri M", "mahaneha*55*26!");

                    // Create the email message
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("mahatamilnadu123@gmail.com");
                    message.To.Add(recipientEmail);
                    message.Subject = subject;
                    message.Body = emailContent;

                    // Send the email
                    await smtpClient.SendMailAsync(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return false;
            }
        }
    }
}
