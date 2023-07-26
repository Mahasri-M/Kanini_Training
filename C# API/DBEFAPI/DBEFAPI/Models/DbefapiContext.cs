using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBEFAPI.Models;

public partial class DbefapiContext : DbContext
{
    public DbefapiContext()
    {
    }

    public DbefapiContext(DbContextOptions<DbefapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS; initial catalog=DBEFAPI; integrated security=SSPI; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("PK__dept__BE2C337D5B96E645");

            entity.ToTable("dept");

            entity.Property(e => e.Deptno)
                .ValueGeneratedNever()
                .HasColumnName("deptno");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .HasColumnName("ename");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("PK__emp__AF4C318A086B47E1");

            entity.ToTable("emp");

            entity.Property(e => e.Empno)
                .ValueGeneratedNever()
                .HasColumnName("empno");
            entity.Property(e => e.Deptno).HasColumnName("deptno");
            entity.Property(e => e.Ename)
                .HasMaxLength(10)
                .HasColumnName("ename");

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Emps)
                .HasForeignKey(d => d.Deptno)
                .HasConstraintName("FK__emp__deptno__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
