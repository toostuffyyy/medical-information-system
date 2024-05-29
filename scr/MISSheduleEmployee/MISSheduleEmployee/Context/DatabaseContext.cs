using System;
using System.Collections.Generic;
using MISSheduleEmployee.Entities;
using Microsoft.EntityFrameworkCore;


namespace MISSheduleEmployee.Context;

public partial class DatabaseContext : DbContext
{
    private static DatabaseContext _context = new DatabaseContext();
    public static DatabaseContext Context => _context;
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Distribution> Distributions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<HistoryChangeSchedure> HistoryChangeSchedures { get; set; }

    public virtual DbSet<Hospitalization> Hospitalizations { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    public virtual DbSet<MedicalBed> MedicalBeds { get; set; }

    public virtual DbSet<MedicalCard> MedicalCards { get; set; }

    public virtual DbSet<MedicalEvent> MedicalEvents { get; set; }

    public virtual DbSet<MedicalWard> MedicalWards { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<ScheduleEmployee> ScheduleEmployees { get; set; }

    public virtual DbSet<SoundMessage> SoundMessages { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StatusDistribution> StatusDistributions { get; set; }

    public virtual DbSet<StatusHospitalization> StatusHospitalizations { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TypeDiagnosis> TypeDiagnoses { get; set; }

    public virtual DbSet<TypeHospitalization> TypeHospitalizations { get; set; }

    public virtual DbSet<TypeMedicalEvent> TypeMedicalEvents { get; set; }

    public virtual DbSet<TypeReception> TypeReceptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MIS GKB BigBoars;Trusted_Connection=True;TrustServerCertificate=true");

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

            entity.HasOne(d => d.DiagnosisNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.DiagnosisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagnosis_TypeDiagnosis");

            entity.HasOne(d => d.MedicalCardNumberNavigation).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.MedicalCardNumber)
                .HasConstraintName("FK_HistoryDiagnosis_MedicalCard");
        });

        modelBuilder.Entity<Distribution>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Distribution");

            entity.HasOne(d => d.Departament).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.DepartamentId)
                .HasConstraintName("FK_Distribution_Department");

            entity.HasOne(d => d.StatusDistribution).WithMany(p => p.Distributions)
                .HasForeignKey(d => d.StatusDistributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Distribution_StatusDistribution");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Doctor");

            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Doctor_Gender");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Specialization");

            entity.HasMany(d => d.MedicalEvents).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeMedicalEvent",
                    r => r.HasOne<MedicalEvent>().WithMany()
                        .HasForeignKey("MedicalEventId")
                        .HasConstraintName("FK_EmployeeMedicalEvent_MedicalEvent"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EmployeeMedicalEvent_Employee"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "MedicalEventId");
                        j.ToTable("EmployeeMedicalEvent");
                    });
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<HistoryChangeSchedure>(entity =>
        {
            entity.ToTable("HistoryChangeSchedure");

            entity.Property(e => e.DateTimeChange).HasColumnType("datetime");
            entity.Property(e => e.NewDate).HasColumnType("datetime");
            entity.Property(e => e.NewTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.NewTimeStart).HasColumnType("datetime");
            entity.Property(e => e.OldDate).HasColumnType("date");
            entity.Property(e => e.OldTimeEnd).HasColumnType("datetime");
            entity.Property(e => e.OldTimeStart).HasColumnType("datetime");

            entity.HasOne(d => d.ScheduleEmployee).WithMany(p => p.HistoryChangeSchedures)
                .HasForeignKey(d => d.ScheduleEmployeeId)
                .HasConstraintName("FK_HistoryChangeSchedure_ScheduleEmployee");
        });

        modelBuilder.Entity<Hospitalization>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Hospitalization");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(50);
            entity.Property(e => e.RealsonForCancel).HasMaxLength(150);
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.MedicalBed).WithMany(p => p.Hospitalizations)
                .HasForeignKey(d => d.MedicalBedId)
                .HasConstraintName("FK_Hospitalization_MedicalBed");

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

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.MedicalEvent).WithMany(p => p.Images)
                .HasForeignKey(d => d.MedicalEventId)
                .HasConstraintName("FK_Images_MedicalEvent");
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

        modelBuilder.Entity<MedicalBed>(entity =>
        {
            entity.ToTable("MedicalBed");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.MedicalWard).WithMany(p => p.MedicalBeds)
                .HasForeignKey(d => d.MedicalWardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalBed_MedicalWard");
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

            entity.HasOne(d => d.MedicalCardNumberNavigation).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.MedicalCardNumber)
                .HasConstraintName("FK_MedicalEvent_MedicalCard");

            entity.HasOne(d => d.Room).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MedicalEvent_Room");

            entity.HasOne(d => d.TypeMedicalEvent).WithMany(p => p.MedicalEvents)
                .HasForeignKey(d => d.TypeMedicalEventId)
                .HasConstraintName("FK_MedicalEvent_TypeMedicalEventId");
        });

        modelBuilder.Entity<MedicalWard>(entity =>
        {
            entity.ToTable("MedicalWard");

            entity.HasOne(d => d.Departament).WithMany(p => p.MedicalWards)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalWard_Department");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.ToTable("Medication");

            entity.Property(e => e.Description).HasMaxLength(250);
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

            entity.Property(e => e.DateExpiry).HasColumnType("date");

            entity.HasOne(d => d.Medication).WithMany(p => p.Parties)
                .HasForeignKey(d => d.MedicationId)
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

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ScheduleEmployee>(entity =>
        {
            entity.ToTable("ScheduleEmployee");

            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.ScheduleEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_ScheduleEmployee_Employee");
        });

        modelBuilder.Entity<SoundMessage>(entity =>
        {
            entity.ToTable("SoundMessage");

            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.MedicalEvent).WithMany(p => p.SoundMessages)
                .HasForeignKey(d => d.MedicalEventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SoundMessage_MedicalEvent");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specialization");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusDistribution>(entity =>
        {
            entity.ToTable("StatusDistribution");

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
