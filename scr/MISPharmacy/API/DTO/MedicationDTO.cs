using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class MedicationDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Dosage { get; set; }

    public string Description { get; set; } = null!;

    public virtual List<PartyDTO> Parties { get; set; } = new List<PartyDTO>();

    [JsonConstructor]
    public MedicationDTO()
    {
        
    }
    public MedicationDTO(Medication medication)
    {
        Id = medication.Id;
        Name = medication.Name;
        Dosage = medication.Dosage;
        Description = medication.Description;
        Parties = medication.Parties.Select(a => new PartyDTO(a)).ToList();
    }
}
