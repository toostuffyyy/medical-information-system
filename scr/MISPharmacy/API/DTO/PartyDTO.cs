using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class PartyDTO
{
    public int Id { get; set; }
    
    public int MedicationId { get; set; }

    public int SupplierId { get; set; }

    public int StorageId { get; set; }
    public DateTime ExpDate { get; set; }

    public double Amount { get; set; }

    public virtual StorageDTO Storage { get; set; } = null!;

    public virtual SupplierDTO Supplier { get; set; } = null!;
    
    [JsonConstructor]
    public PartyDTO() { }
    public PartyDTO(Party party)
    {
        Id = party.Id;
        MedicationId = party.MedicationId;
        SupplierId = party.SupplierId;
        StorageId = party.StorageId;
        ExpDate = party.ExpDate;
        Amount = party.Amount;
        Storage = new StorageDTO(party.Storage);
        Supplier = new SupplierDTO(party.Supplier);
    }
}
