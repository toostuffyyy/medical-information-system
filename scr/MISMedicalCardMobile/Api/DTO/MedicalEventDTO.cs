using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class MedicalEventDTO
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
