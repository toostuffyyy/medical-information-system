using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class InsuranceCompany
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; } = new List<InsurancePolicy>();
}
