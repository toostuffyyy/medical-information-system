using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class MedicalBed
{
    public int Id { get; set; }

    public int MedicalWardId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual MedicalWard MedicalWard { get; set; } = null!;
}
