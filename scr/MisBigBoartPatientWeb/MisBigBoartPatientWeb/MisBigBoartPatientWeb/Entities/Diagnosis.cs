using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class Diagnosis
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DiagnosisId { get; set; }

    public string? Anamnesis { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual MedicalCard MedicalCardNumberNavigation { get; set; } = null!;
}
