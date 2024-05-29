using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class InsuranceCompanyDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public InsuranceCompanyDTO(InsuranceCompany insuranceCompany)
    {
        Id = insuranceCompany.Id;
        Name = insuranceCompany.Name;
    }
}
