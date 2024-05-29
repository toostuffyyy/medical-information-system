using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Departament
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();

    public virtual ICollection<MedicalWard> MedicalWards { get; set; } = new List<MedicalWard>();
}
