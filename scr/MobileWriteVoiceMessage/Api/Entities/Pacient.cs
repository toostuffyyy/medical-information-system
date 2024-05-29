using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Pacient
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual MedicalCard? MedicalCard { get; set; }

    public virtual MidicalInsurance? MidicalInsurance { get; set; }

    public virtual Passport? Passport { get; set; }
}
