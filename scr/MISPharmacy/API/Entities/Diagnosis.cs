using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Diagnosis
{
    public int Id { get; set; }

    public int MedicalCardId { get; set; }

    public int DiagnosisType { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public virtual DiagnosisType DiagnosisTypeNavigation { get; set; } = null!;

    public virtual MedicalCard MedicalCard { get; set; } = null!;
}
