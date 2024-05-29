using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class MedicalCardDTO
{
    public int Number { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastVisitDate { get; set; }

    public DateTime? NextVisitDate { get; set; }

    public virtual PatientDTO Patient { get; set; } = null!;

    public MedicalCardDTO(MedicalCard medicalCard)
    {
        Number = medicalCard.Number;
        CreateDate = medicalCard.CreateDate;
        LastVisitDate = medicalCard.LastVisitDate;
        NextVisitDate = medicalCard.NextVisitDate;
        Patient = new PatientDTO(medicalCard.Patient);
    }
}
