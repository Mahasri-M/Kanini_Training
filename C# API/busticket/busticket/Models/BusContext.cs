using Microsoft.EntityFrameworkCore;

namespace busticket.Models
{
    public class BusContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Register> Registers { get; set; }
         public DbSet<Busdetails> Busdetailss { get; set; }
        public BusContext(DbContextOptions<BusContext>
           dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
