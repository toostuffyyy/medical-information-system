using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class MedicalWard
{
    public int Id { get; set; }

    public int DepartamentId { get; set; }

    public virtual Departament Departament { get; set; } = null!;

    public virtual ICollection<MedicalBed> MedicalBeds { get; set; } = new List<MedicalBed>();
}
