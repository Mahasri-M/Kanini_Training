using Models;
using System.Collections.Generic;

namespace AppointmentManage.Data
{
    public class MicroContext : DbContext
    {
        public MicroContext(DbContextOptions<MicroContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }

    }
}
