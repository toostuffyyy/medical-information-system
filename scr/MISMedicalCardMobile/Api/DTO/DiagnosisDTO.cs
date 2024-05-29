using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class DiagnosisDTO
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DiagnosisId { get; set; }

    public string? Anamnesis { get; set; }

    public DateTime Date { get; set; }
}
