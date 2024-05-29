using System;

namespace MISMedicalCardMobile1.Models;

public class Patient
{
    public int Id { get; set; }
    
    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int PassportSeries { get; set; }

    public int PassportNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Address { get; set; } = null!;

    public string? PlaceOfWork { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Photo { get; set; }

    public Gender Gender { get; set; } = null!;

    public InsurancePolicy? InsurancePolicy { get; set; }
}