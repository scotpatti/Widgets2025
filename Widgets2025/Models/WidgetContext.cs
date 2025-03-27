using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Widgets2025.Models;

public partial class WidgetContext : DbContext
{
    public WidgetContext()
    {
    }

    public WidgetContext(DbContextOptions<WidgetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Widget> Widgets { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__049E3A8921E47E84");

            entity.ToTable("Customer");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CreditRating)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LName");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleNumber).HasName("PK__Sales__5C16AF1C312705EB");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.WidgetId).HasColumnName("WidgetID");

            entity.HasOne(d => d.Cust).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("Sales_Cust_FK");

            entity.HasOne(d => d.Widget).WithMany(p => p.Sales)
                .HasForeignKey(d => d.WidgetId)
                .HasConstraintName("Sales_Widget_FK");
        });

        modelBuilder.Entity<Widget>(entity =>
        {
            entity.HasKey(e => e.WidgetId).HasName("PK__Widgets__ADFD3072511DBCE9");

            entity.Property(e => e.WidgetId).HasColumnName("WidgetID");
            entity.Property(e => e.CurrentPrice).HasColumnType("money");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
