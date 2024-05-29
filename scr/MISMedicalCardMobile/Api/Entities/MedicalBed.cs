using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class MedicalBed
{
    public int Id { get; set; }

    public int MedicalWardId { get; set; }

    public int? HospitalizationId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Hospitalization? Hospitalization { get; set; }

    public virtual MedicalWard MedicalWard { get; set; } = null!;
}
