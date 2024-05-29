using System;
using System.Collections.Generic;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public partial class DataBaseContext : DbContext
{
    private static Lazy<DataBaseContext> _context = new Lazy<DataBaseContext>(new DataBaseContext());
    public static DataBaseContext Context => _context.Value;
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<DiagnosisType> DiagnosisTypes { get; set; }

    public virtual DbSet<Distribution> Distributions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    public virtual DbSet<MedicalBed> MedicalBeds { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MedicalEvent> MedicalEvents { get; set; }

    public virtual DbSet<MedicalEventType> MedicalEventTypes { get; set; }

    public virtual DbSet<MedicalWard> MedicalWards { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StatusHospitalization> StatusHospitalizations { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TypeHospitalization> TypeHospitalizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;DataBase=user23;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departament>(entity =>
        {
            entity.ToTable("Departament");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.ToTable("Diagnosis");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(150);

            entity.HasOne(d => d.DiagnosisTypeNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.DiagnosisType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagnosis_DiagnosisType");

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.MedicalCardId)
                .HasConstraintName("FK_Diagnosis_MedicalCard");
        });

        modelBuilder.Entity<DiagnosisType>(entity =>
        {
            entity.ToTable("DiagnosisType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            entity.ToTable("Distribution");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Departament).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Departament");

            entity.HasOne(d => d.Medication).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Medication");

            entity.HasOne(d => d.Storage).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Storage");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_Supplier");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Gender");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SpecializationId)
                .HasConstraintName("FK_Employee_Specialization");

            entity.HasMany(d => d.MedicalEvents).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeMedicalEvent",
                    r => r.HasOne<MedicalEvent>().WithMany()
                        .HasForeignKey("MedicalEventId")
                        .HasConstraintName("FK_Employee/MedicalEvent_MedicalEvent"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_Employee/MedicalEvent_Employee"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "MedicalEventId");
                        j.ToTable("Employee/MedicalEvent");
                    });
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.ToTable("Hospitalization");

            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.RealsonForCancel).HasMaxLength(150);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MedicalEvent).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.MedicalEventId)
                .HasConstraintName("FK_Hospitalization_MedicalEvent");

            entity.HasOne(d => d.StatusHospitalization).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.StatusHospitalizationId)
                .HasConstraintName("FK_Hospitalization_StatusHospitalization");

            entity.HasOne(d => d.TypeHospitalization).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.TypeHospitalizationId)
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

            entity.HasOne(d => d.InsuranceCompanyNavigation).WithMany(p => p.InsurancePolicies)
                .HasForeignKey(d => d.InsuranceCompanyId)
                .HasConstraintName("FK_InsurancePolicy_Patient");
        });

        modelBuilder.Entity<MedicalBed>(entity =>
        {
            entity.ToTable("MedicalBed");

            entity.Property(e => e.Chat)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Hospitalization).WithMany(p => p.MedicalBeds)
                .HasForeignKey(d => d.HospitalizationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalBed_Hospitalization");

            entity.HasOne(d => d.MedicalWard).WithMany(p => p.MedicalBeds)
                .HasForeignKey(d => d.MedicalWardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalBed_MedicalWard");
        });

        modelBuilder.Entity<MedicalCard>(entity =>
        {
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

            entity.HasOne(d => d.MedicalCard).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.MedicalCardId)
                .HasConstraintName("FK_MedicalEvent_MedicalCard");

            entity.HasOne(d => d.MedicalEventType).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.MedicalEventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalEvent_MedicalEventType");

            entity.HasMany(d => d.Medications).WithMany(p => p.MedicalEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "Recipe",
                    r => r.HasOne<Medication>().WithMany()
                        .HasForeignKey("MedicationId")
                        .HasConstraintName("FK_Recipe_Medication"),
                    l => l.HasOne<MedicalEvent>().WithMany()
                        .HasForeignKey("MedicalEventId")
                        .HasConstraintName("FK_Recipe_MedicalEvent"),
                    j =>
                    {
                        j.HasKey("MedicalEventId", "MedicationId");
                        j.ToTable("Recipe");
                    });
        });

        modelBuilder.Entity<MedicalEventType>(entity =>
        {
            entity.ToTable("MedicalEventType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<MedicalWard>(entity =>
        {
            entity.ToTable("MedicalWard");

            entity.HasOne(d => d.Departament).WithMany(p => p.MedicalWards)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalWard_Departament");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medication");

            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Medication).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Medication");

            entity.HasOne(d => d.Storage).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Storage");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Supplier");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.ToTable("Party");

            entity.Property(e => e.ExpDate).HasColumnType("date");

            entity.HasOne(d => d.Medication).WithMany(p => p.Parties)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Party_Medication");

            entity.HasOne(d => d.Storage).WithMany(p => p.Parties)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Party_Storage");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Parties)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Party_Supplier");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.DataOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassportNumber).HasMaxLength(6);
            entity.Property(e => e.PassportSerial).HasMaxLength(4);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.PlaceOfWork).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Patients)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
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

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.ToTable("Storage");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TypeHospitalization>(entity =>
        {
            entity.ToTable("TypeHospitalization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
