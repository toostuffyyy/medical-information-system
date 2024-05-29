using System;

namespace MISMedicalCardMobile1.Models;

public class MedicalEvent
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int DoctorId { get; set; }

    public int TypeMedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Recommendation { get; set; }

    public string? Result { get; set; }
}