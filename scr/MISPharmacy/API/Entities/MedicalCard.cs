using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class MedicalCard
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastVisitDate { get; set; }

    public DateTime NextVisitDate { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();

    public virtual Patient Patient { get; set; } = null!;
}
