using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class Medication
{
    public int Id { get; set; }

    public int TypeReceptionId { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public virtual TypeReception TypeReception { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; } = new List<MedicalEvent>();
}
