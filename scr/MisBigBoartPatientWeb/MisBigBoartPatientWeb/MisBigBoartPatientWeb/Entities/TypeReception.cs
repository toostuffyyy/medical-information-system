using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class TypeReception
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medication> Medications { get; } = new List<Medication>();
}
