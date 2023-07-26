using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBF_Food.Models;

public partial class FoodContext : DbContext
{
    public FoodContext()
    {
    }

    public FoodContext(DbContextOptions<FoodContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomerDet> CustomerDets { get; set; }

    public virtual DbSet<FoodType> FoodTypes { get; set; }

    public virtual DbSet<OrderDet> OrderDets { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //       => optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS; initial catalog=food; integrated security=SSPI; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__category__213EE774C0618B55");

            entity.ToTable("category");

            entity.Property(e => e.CId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("c_id");
            entity.Property(e => e.CType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_type");
        });

        modelBuilder.Entity<CustomerDet>(entity =>
        {
            entity.HasKey(e => e.MobNum).HasName("PK__customer__2F099EBE4EF481F4");

            entity.ToTable("customer_det");

            entity.Property(e => e.MobNum)
                .ValueGeneratedNever()
                .HasColumnName("mob_num");
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__food_typ__2C000598F4B279E4");

            entity.ToTable("food_type");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.Specification)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("specification");
        });

        modelBuilder.Entity<OrderDet>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__order_de__46596229A16294DD");

            entity.ToTable("order_det");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Amt).HasColumnName("amt");
            entity.Property(e => e.MobNum).HasColumnName("mob_num");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.MobNumNavigation).WithMany(p => p.OrderDets)
                .HasForeignKey(d => d.MobNum)
                .HasConstraintName("FK__order_det__mob_n__412EB0B6");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.OrderDets)
                .HasForeignKey(d => d.PId)
                .HasConstraintName("FK__order_det__p_id__4222D4EF");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentNo).HasName("PK__payment__ED1FE109AB05AA1D");

            entity.ToTable("payment");

            entity.Property(e => e.PaymentNo).HasColumnName("payment_no");
            entity.Property(e => e.PayId).HasColumnName("pay_id");
            entity.Property(e => e.Totalamt).HasColumnName("totalamt");

            entity.HasOne(d => d.Pay).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PayId)
                .HasConstraintName("FK__payment__pay_id__46E78A0C");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PayId).HasName("PK__payment___7AAD1CEAF848E2F1");

            entity.ToTable("payment_type");

            entity.Property(e => e.PayId)
                .ValueGeneratedNever()
                .HasColumnName("pay_id");
            entity.Property(e => e.PayType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("pay_type");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__product__82E06B918A251C0D");

            entity.ToTable("product");

            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.CId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("c_id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.PName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("p_name");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__product__c_id__3D5E1FD2");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__product__type_id__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
