using System;
using System.Collections.Generic;
using ExamApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamApp.DAL;

public partial class ExamAppDbContext : DbContext
{
    IConfiguration _configuration;
    public ExamAppDbContext()
    {
    }

    public ExamAppDbContext(DbContextOptions<ExamAppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Ders> Ders { get; set; }

    public virtual DbSet<Imtahan> Imtahan { get; set; }

    public virtual DbSet<Shagird> Shagird { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Ders>(entity =>
        {
            entity.HasKey(e => e.Kod);

            entity.Property(e => e.Kod)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ad)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MuellimAd)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MuellimSoyad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sinif).HasColumnType("numeric(2, 0)");
        });

        modelBuilder.Entity<Shagird>(entity =>
        {
            entity.HasKey(e => e.Nomre).HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            entity.Property(e => e.Nomre).HasColumnType("numeric(5, 0)");
            entity.Property(e => e.Ad)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Sinif).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Soyad)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Imtahan>(entity =>
        {
            entity.HasKey(e => e.Nomre);

            entity.Property(e => e.Nomre)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(14, 0)");
            entity.Property(e => e.DersKod)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Qiymet).HasColumnType("numeric(1, 0)");
            entity.Property(e => e.ShagirdNomre).HasColumnType("numeric(5, 0)");
        });

        modelBuilder.Entity<Imtahan>()
        .HasOne(i => i.Ders)
        .WithMany(d => d.Imtahanlar)
        .HasForeignKey(i => i.DersKod);

        modelBuilder.Entity<Imtahan>()
        .HasOne(i => i.Shagird)
        .WithMany(s => s.Imtahanlar)
        .HasForeignKey(i => i.ShagirdNomre);

        modelBuilder.Entity<Ders>().HasData(
            new Ders { Kod = "RIY", Ad = "Riyaziyyat", MuellimAd = "Riyaziyyat Muellimi", MuellimSoyad = "Riyaziyyat Muellimi", Sinif=9 },
            new Ders { Kod = "FIZ", Ad = "Fizika", MuellimAd = "Fizika Muellimi", MuellimSoyad = "Fizika Muellimi", Sinif=9 }
        );

        modelBuilder.Entity<Shagird>().HasData(
            new Shagird { Nomre= 12345, Ad="Shagird1",  Soyad="Shagird1", Sinif=9 },
            new Shagird { Nomre= 54321, Ad="Shagird1",  Soyad="Shagird1", Sinif=9 }
        );

        modelBuilder.Entity<Imtahan>().HasData(
            new Imtahan { Nomre=123, DersKod = "RIY", ShagirdNomre= 12345, Tarix= DateTime.Now, Qiymet= 9},
            new Imtahan { Nomre=124, DersKod = "FIZ", ShagirdNomre= 54321, Tarix= DateTime.Now, Qiymet= 9}
        );

    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
