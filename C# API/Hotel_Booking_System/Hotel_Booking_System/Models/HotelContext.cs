using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Models
{
    public class HotelContext:DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }
    }
}
