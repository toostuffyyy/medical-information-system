using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class MedicalBed
{
    public int Id { get; set; }

    public int HospitalizationId { get; set; }

    public int MedicalWardId { get; set; }

    public string Chat { get; set; } = null!;

    public virtual Hospitalization Hospitalization { get; set; } = null!;

    public virtual MedicalWard MedicalWard { get; set; } = null!;
}
