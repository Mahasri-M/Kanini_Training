using Microsoft.EntityFrameworkCore;

namespace CFAPI.Models
{
    public class CompanyContextCF : DbContext
    {
        public CompanyContextCF(DbContextOptions<CompanyContextCF> options) : base(options) 
        {
            
        }
        public DbSet<Dept>Depts { get; set; }
        public DbSet<Emp > emps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
