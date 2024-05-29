using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class InsuranceCompany
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MidicalInsurance> MidicalInsurances { get; set; } = new List<MidicalInsurance>();
}
