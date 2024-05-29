using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class MedicalWard
{
    public int Id { get; set; }

    public int DepartamentId { get; set; }

    public virtual Department Departament { get; set; } = null!;

    public virtual ICollection<MedicalBed> MedicalBeds { get; set; } = new List<MedicalBed>();
}
