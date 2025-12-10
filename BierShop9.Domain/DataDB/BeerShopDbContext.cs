using System;
using System.Collections.Generic;
using BierShop9.Domain.EntitiesDB;
using Microsoft.EntityFrameworkCore;

namespace BierShop9.Domain.DataDB;

public partial class BeerShopDbContext : DbContext
{
    public BeerShopDbContext()
    {
    }

    public BeerShopDbContext(DbContextOptions<BeerShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Brewery> Breweries { get; set; }

    public virtual DbSet<Variety> Varieties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=.\\SQL22_VIVES; Database=biersql; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Biernr).HasName("PK_Bieren");

            entity.Property(e => e.Alcohol).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.BrouwernrNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.Brouwernr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bieren_Brouwerij");

            entity.HasOne(d => d.SoortnrNavigation).WithMany(p => p.Beers)
                .HasForeignKey(d => d.Soortnr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bieren_Soorten");
        });

        modelBuilder.Entity<Brewery>(entity =>
        {
            entity.HasKey(e => e.Brouwernr).HasName("PK_Brouwerij");

            entity.Property(e => e.Brouwernr).ValueGeneratedNever();
            entity.Property(e => e.Adres)
                .HasMaxLength(60)
                .IsFixedLength();
            entity.Property(e => e.Gemeente)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.Naam)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Omzet).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Variety>(entity =>
        {
            entity.HasKey(e => e.Soortnr).HasName("PK_Soorten");

            entity.Property(e => e.Soortnr).ValueGeneratedNever();
            entity.Property(e => e.Soortnaam)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
