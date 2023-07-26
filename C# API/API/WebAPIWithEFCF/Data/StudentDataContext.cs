using Microsoft.EntityFrameworkCore;

namespace WebAPIWithEFCF.Data
{
    
    public class StudentDataContext :DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentDataContext(DbContextOptions<StudentDataContext> 
            dbContextOptions):base(dbContextOptions)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=StudentDB; integrated security=SSPI;TrustServerCertificate=True;");
        }

    }
}
