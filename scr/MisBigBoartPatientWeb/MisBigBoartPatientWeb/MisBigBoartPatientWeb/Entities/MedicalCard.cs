using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class MedicalCard
{
    public int Number { get; set; }

    public int PatientId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastVisitDate { get; set; }

    public DateTime? NextVisitDate { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; } = new List<Diagnosis>();

    public virtual ICollection<MedicalEvent> MedicalEvents { get; } = new List<MedicalEvent>();

    public virtual Patient Patient { get; set; } = null!;
}
