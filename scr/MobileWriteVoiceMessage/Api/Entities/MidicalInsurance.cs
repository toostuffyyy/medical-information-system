using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class MidicalInsurance
{
    public int IdPacient { get; set; }

    public string Number { get; set; } = null!;

    public int IdInsuranceCompany { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual InsuranceCompany IdInsuranceCompanyNavigation { get; set; } = null!;

    public virtual Pacient IdPacientNavigation { get; set; } = null!;
}
