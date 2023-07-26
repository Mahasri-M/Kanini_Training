using Models;
using System.Collections.Generic;

namespace DoctorManage.Data
{
    public class MicroContext : DbContext
    {
        public MicroContext(DbContextOptions<MicroContext> options) : base(options) { }

        public DbSet<DoctorDetails> DoctorDetails { get; set; }

    }
}
