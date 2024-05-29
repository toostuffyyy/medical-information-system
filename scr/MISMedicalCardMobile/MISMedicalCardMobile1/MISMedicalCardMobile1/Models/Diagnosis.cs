using System;

namespace MISMedicalCardMobile1.Models;

public class Diagnosis
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DiagnosisId { get; set; }

    public string? Anamnesis { get; set; }

    public DateTime Date { get; set; }
}