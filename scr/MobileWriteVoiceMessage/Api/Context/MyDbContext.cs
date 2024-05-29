using System;
using System.Collections.Generic;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MidicalInsurance> MidicalInsurances { get; set; }

    public virtual DbSet<Pacient> Pacients { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<SoundMessage> SoundMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=professional_2024;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InsuranceCompany>(entity =>
        {
            entity.ToTable("InsuranceCompany");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
            entity.HasKey(e => e.IdPacient);

            entity.ToTable("MedicalCard");

            entity.Property(e => e.IdPacient).ValueGeneratedNever();
            entity.Property(e => e.DateCreate).HasColumnType("datetime");

            entity.HasOne(d => d.IdPacientNavigation).WithOne(p => p.MedicalCard)
                .HasForeignKey<MedicalCard>(d => d.IdPacient)
                .HasConstraintName("FK_MedicalCard_Pacient");
        });

        modelBuilder.Entity<MidicalInsurance>(entity =>
        {
            entity.HasKey(e => e.IdPacient);

            entity.ToTable("MidicalInsurance");

            entity.Property(e => e.IdPacient).ValueGeneratedNever();
            entity.Property(e => e.DateEnd).HasColumnType("datetime");
            entity.Property(e => e.Number).HasMaxLength(25);

            entity.HasOne(d => d.IdInsuranceCompanyNavigation).WithMany(p => p.MidicalInsurances)
                .HasForeignKey(d => d.IdInsuranceCompany)
                .HasConstraintName("FK_MidicalInsurance_InsuranceCompany");

            entity.HasOne(d => d.IdPacientNavigation).WithOne(p => p.MidicalInsurance)
                .HasForeignKey<MidicalInsurance>(d => d.IdPacient)
                .HasConstraintName("FK_MidicalInsurance_Pacient");
        });

        modelBuilder.Entity<Pacient>(entity =>
        {
            entity.ToTable("Pacient");

            entity.Property(e => e.Adress).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(25);
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.IdPacient);

            entity.ToTable("Passport");

            entity.Property(e => e.IdPacient).ValueGeneratedNever();
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PassportSeries).HasMaxLength(50);

            entity.HasOne(d => d.IdPacientNavigation).WithOne(p => p.Passport)
                .HasForeignKey<Passport>(d => d.IdPacient)
                .HasConstraintName("FK_Passport_Pacient");
        });

        modelBuilder.Entity<SoundMessage>(entity =>
        {
            entity.ToTable("SoundMessage");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NameFile)
                .HasMaxLength(250)
                .HasColumnName("name_file");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
