using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPIWithEFDBFirst.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=StudentDB; integrated security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudId);

            entity.Property(e => e.StudId).ValueGeneratedNever();
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Pin).HasColumnName("pin");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
