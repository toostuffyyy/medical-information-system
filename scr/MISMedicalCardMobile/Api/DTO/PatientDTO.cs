using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public sealed partial class PatientDTO
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

    public GenderDTO Gender { get; set; } = null!;

    public InsurancePolicyDTO? InsurancePolicy { get; set; }

    public PatientDTO(Patient patient)
    {
        Id = patient.Id;
        Surname = patient.Surname;
        Name = patient.Name;
        Patronymic = patient.Patronymic;
        PassportSeries = patient.PassportSeries;
        PassportNumber = patient.PassportNumber;
        DateOfBirth = patient.DateOfBirth;
        Address = patient.Address;
        PlaceOfWork = patient.PlaceOfWork;
        PhoneNumber = patient.PhoneNumber;
        Email = patient.Email;
        Photo = patient.Photo;
        Gender = new GenderDTO(patient.Gender);
        InsurancePolicy = new InsurancePolicyDTO(patient.InsurancePolicies.ToList()[0]);
    }
}
