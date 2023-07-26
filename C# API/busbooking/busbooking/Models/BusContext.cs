using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace busbooking.Models
{
    public class BusContext: DbContext
    {
        public DbSet<Register> Registers { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Img> Imgs { get; set; }

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
