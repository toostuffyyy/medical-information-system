using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class TypeReception
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
}
