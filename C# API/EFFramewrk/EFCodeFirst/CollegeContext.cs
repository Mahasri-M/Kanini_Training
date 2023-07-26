using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    internal class CollegeContext:DbContext
    {
       public DbSet<student>  students {  get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=LAPTOP-EE8FKNGK\\SQLEXPRESS;" +
                "initial catalog=College; integrated security=SSPI;" +
                "TrustServerCertificate=True;");
        }
    }
}
