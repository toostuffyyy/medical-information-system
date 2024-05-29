using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Hospitalization
{
    public int Id { get; set; }

    public int StatusHospitalizationId { get; set; }

    public int TypeHospitalizationId { get; set; }

    public int MedicalEventId { get; set; }

    public string Purpose { get; set; } = null!;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Description { get; set; }

    public string? RealsonForCancel { get; set; }

    public virtual ICollection<MedicalBed> MedicalBeds { get; set; } = new List<MedicalBed>();

    public virtual MedicalEvent MedicalEvent { get; set; } = null!;

    public virtual StatusHospitalization StatusHospitalization { get; set; } = null!;

    public virtual TypeHospitalization TypeHospitalization { get; set; } = null!;
}
