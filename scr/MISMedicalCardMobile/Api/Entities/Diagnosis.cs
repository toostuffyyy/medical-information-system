using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Diagnosis
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DiagnosisId { get; set; }

    public string? Anamnesis { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual TypeDiagnosis DiagnosisNavigation { get; set; } = null!;

    public virtual MedicalCard MedicalCardNumberNavigation { get; set; } = null!;
}
