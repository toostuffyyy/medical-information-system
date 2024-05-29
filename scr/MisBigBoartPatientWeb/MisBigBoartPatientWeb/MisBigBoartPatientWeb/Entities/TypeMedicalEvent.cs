using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class TypeMedicalEvent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; } = new List<MedicalEvent>();
}
