using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dmaws_20012024.Entities;

public partial class OrderSystemContext : DbContext
{
    public static String connectionString;
    public OrderSystemContext()
    {
    }

    public OrderSystemContext(DbContextOptions<OrderSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderTbl> OrderTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderTbl>(entity =>
        {
            entity.HasKey(e => e.ItemCode).HasName("PK__OrderTbl__3ECC0FEBDA86DDAD");

            entity.ToTable("OrderTbl");

            entity.Property(e => e.ItemName).HasMaxLength(100);
            entity.Property(e => e.OrderAddress).HasMaxLength(255);
            entity.Property(e => e.OrderDelivery).HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
