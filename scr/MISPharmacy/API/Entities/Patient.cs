using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Patient
{
    public int Id { get; set; }

    public int GenderId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string PassportSerial { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public DateTime DataOfBirth { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PlaceOfWork { get; set; } = null!;

    public string? Image { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();

    public virtual ICollection<MedicalCard> MedicalCards { get; set; } = new List<MedicalCard>();
}
