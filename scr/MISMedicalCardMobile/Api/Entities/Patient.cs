using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Patient
{
    public int Id { get; set; }

    public int GenderId { get; set; }

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

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();

    public virtual ICollection<MedicalCard> MedicalCards { get; set; } = new List<MedicalCard>();
}
