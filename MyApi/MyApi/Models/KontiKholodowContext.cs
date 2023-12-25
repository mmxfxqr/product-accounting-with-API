using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Models;

public partial class KontiKholodowContext : DbContext
{
    public KontiKholodowContext()
    {
    }

    public KontiKholodowContext(DbContextOptions<KontiKholodowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<UserAuthorization> UserAuthorizations { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=K27-09\\SQLEXPRESS;Database=Kholodow;User id=sa; Password=111;Encrypt=false");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Amount).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.IdProvider);

            entity.ToTable("Provider");

            entity.Property(e => e.IdProvider).HasColumnName("idProvider");
            entity.Property(e => e.CityProvider)
                .HasMaxLength(50)
                .HasColumnName("City_provider");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .HasColumnName("Company_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.IdStock);

            entity.ToTable("Stock");

            entity.Property(e => e.IdStock).HasColumnName("idStock");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.IdWorkers).HasColumnName("idWorkers");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdWorkersNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdWorkers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Workers");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.IdSupplies);

            entity.Property(e => e.IdSupplies).HasColumnName("idSupplies");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdProvider).HasColumnName("idProvider");
            entity.Property(e => e.IdStock).HasColumnName("idStock");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplies_Products");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplies_Provider");

            entity.HasOne(d => d.IdStockNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IdStock)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplies_Stock");
        });

        modelBuilder.Entity<UserAuthorization>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User_authorization");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorkers);

            entity.Property(e => e.IdWorkers).HasColumnName("idWorkers");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Phone_number");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
