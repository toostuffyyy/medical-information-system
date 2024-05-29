using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Hospitalization
{
    public int Code { get; set; }

    public int MedicalEventId { get; set; }

    public int StatusHospitalizationId { get; set; }

    public int TypeHospotalizationId { get; set; }

    public string Purpose { get; set; } = null!;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? RealsonForCancel { get; set; }

    public virtual ICollection<MedicalBed> MedicalBeds { get; set; } = new List<MedicalBed>();

    public virtual MedicalEvent MedicalEvent { get; set; } = null!;

    public virtual StatusHospitalization StatusHospitalization { get; set; } = null!;

    public virtual TypeHospitalization TypeHospotalization { get; set; } = null!;
}
