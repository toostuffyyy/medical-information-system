using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class DistributionDTO
{
    public int Id { get; set; }
    
    public int DepartamentId { get; set; }

    public int MedicationId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }
    
    public DateTime Date { get; set; }

    public double Amount { get; set; }

    public bool IsApproved { get; set; }
    
    public virtual DepartamentDTO Departament { get; set; } = null!;

    public virtual MedicationDTO Medication { get; set; } = null!;

    public virtual StorageDTO Storage { get; set; } = null!;

    public virtual SupplierDTO Supplier { get; set; } = null!;

    [JsonConstructor]
    public DistributionDTO()
    {
        
    }
    public DistributionDTO(Distribution distribution)
    {
        Id = distribution.Id;
        DepartamentId = distribution.MedicationId;
        MedicationId = distribution.MedicationId;
        SupplierId = distribution.SupplierId;
        StorageId = distribution.StorageId;
        Date = distribution.Date;
        Amount = distribution.Amount;
        IsApproved = distribution.IsApproved;
        Departament = new DepartamentDTO(distribution.Departament);
        Medication = new MedicationDTO(distribution.Medication);
        Storage = new StorageDTO(distribution.Storage);
        Supplier = new SupplierDTO(distribution.Supplier);
    }
}
