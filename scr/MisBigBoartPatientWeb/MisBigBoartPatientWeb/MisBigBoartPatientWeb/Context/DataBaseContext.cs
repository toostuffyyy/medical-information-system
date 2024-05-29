using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MisBigBoartPatientWeb.Entities;

namespace MisBigBoartPatientWeb.Context;

public partial class DataBaseContext : DbContext
{
    
    private static DataBaseContext _context = new DataBaseContext();
    public static DataBaseContext Context() => _context;
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MedicalEvent> MedicalEvents { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StatusHospitalization> StatusHospitalizations { get; set; }

    public virtual DbSet<TypeDiagnosis> TypeDiagnoses { get; set; }

    public virtual DbSet<TypeHospitalization> TypeHospitalizations { get; set; }

    public virtual DbSet<TypeMedicalEvent> TypeMedicalEvents { get; set; }

    public virtual DbSet<TypeReception> TypeReceptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S9N70VV\\EVGENIY_LYKHOV;DataBase=MIS GKB BigBoars;User Id=Evgeniy_Lykhov;Password=1;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HistoryDiagnosis");

            entity.ToTable("Diagnosis");

            entity.Property(e => e.Anamnesis).HasMaxLength(250);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(250);

            entity.HasOne(d => d.MedicalCardNumberNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.MedicalCardNumber)
                .HasConstraintName("FK_HistoryDiagnosis_MedicalCard");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("Doctor");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Doctor_Gender");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Specialization");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Hospitalization");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.RealsonForCancel).HasMaxLength(150);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Hospitalization_Department");

            entity.HasOne(d => d.MedicalEvent).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.MedicalEventId)
                .HasConstraintName("FK_Hospitalization_MedicalEvent");

            entity.HasOne(d => d.StatusHospitalization).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.StatusHospitalizationId)
                .HasConstraintName("FK_Hospitalization_StatusHospitalization");

            entity.HasOne(d => d.TypeHospotalization).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.TypeHospotalizationId)
                .HasConstraintName("FK_Hospitalization_TypeHospitalization");
        });

        modelBuilder.Entity<InsuranceCompany>(entity =>
        {
            entity.ToTable("InsuranceCompany");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<InsurancePolicy>(entity =>
        {
            entity.HasKey(e => e.Number);

            entity.ToTable("InsurancePolicy");

            entity.Property(e => e.Number).ValueGeneratedNever();
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.InsuranceCompanyId)
                .HasConstraintName("FK_InsurancePolicy_InsuranceCompany");

            entity.HasOne(d => d.Patient).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_InsurancePolicy_Patient");
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
            entity.HasKey(e => e.Number);

            entity.ToTable("MedicalCard");

            entity.Property(e => e.CreateDate).HasColumnType("date");
            entity.Property(e => e.LastVisitDate).HasColumnType("date");
            entity.Property(e => e.NextVisitDate).HasColumnType("date");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalCards)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_MedicalCard_Patient");
        });

        modelBuilder.Entity<MedicalEvent>(entity =>
        {
            entity.ToTable("MedicalEvent");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Recommendation).HasMaxLength(250);
            entity.Property(e => e.Result).HasMaxLength(250);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalEvent_Doctor");

            entity.HasOne(d => d.MedicalCardNumberNavigation).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.MedicalCardNumber)
                .HasConstraintName("FK_MedicalEvent_MedicalCard");

            entity.HasOne(d => d.TypeMedicalEvent).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.TypeMedicalEventId)
                .HasConstraintName("FK_MedicalEvent_TypeMedicalEventId");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medication");

            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.TypeReception).WithMany(p => p.Medications)
                .HasForeignKey(d => d.TypeReceptionId)
                .HasConstraintName("FK_Medication_TypeReception");

            entity.HasMany(d => d.MedicalEvents).WithMany(p => p.Medications)
                .UsingEntity<Dictionary<string, object>>(
                    "Recide",
                    r => r.HasOne<MedicalEvent>().WithMany()
                        .HasForeignKey("MedicalEventId")
                        .HasConstraintName("FK_Recide_MedicalEvent"),
                    l => l.HasOne<Medication>().WithMany()
                        .HasForeignKey("MedicationId")
                        .HasConstraintName("FK_Recide_Medication"),
                    j =>
                    {
                        j.HasKey("MedicationId", "MedicalEventId");
                        j.ToTable("Recide");
                    });
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Patients");

            entity.ToTable("Patient");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Photo).HasMaxLength(150);
            entity.Property(e => e.PlaceOfWork).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Patients)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Patient_Gender");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specialization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusHospitalization>(entity =>
        {
            entity.ToTable("StatusHospitalization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeDiagnosis>(entity =>
        {
            entity.ToTable("TypeDiagnosis");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeHospitalization>(entity =>
        {
            entity.ToTable("TypeHospitalization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeMedicalEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TypeMedicalEventId");

            entity.ToTable("TypeMedicalEvent");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeReception>(entity =>
        {
            entity.ToTable("TypeReception");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
