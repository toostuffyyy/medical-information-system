using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class MedicalEvent
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DoctorId { get; set; }

    public int TypeMedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string Recommendation { get; set; } = null!;

    public string Result { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; } = new List<Hospitalization>();

    public virtual MedicalCard MedicalCardNumberNavigation { get; set; } = null!;

    public virtual TypeMedicalEvent TypeMedicalEvent { get; set; } = null!;

    public virtual ICollection<Medication> Medications { get; } = new List<Medication>();
}
