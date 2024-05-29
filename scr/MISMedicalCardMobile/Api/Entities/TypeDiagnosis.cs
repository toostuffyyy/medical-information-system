using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class TypeDiagnosis
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
}
