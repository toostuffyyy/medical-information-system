using System;
using System.Collections.Generic;

namespace MISSheduleEmployee.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();

    public virtual ICollection<MedicalWard> MedicalWards { get; set; } = new List<MedicalWard>();
}
