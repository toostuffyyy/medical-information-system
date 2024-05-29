using System;
using System.Collections.Generic;
using Api.DTO;
using Api.Entities;

namespace Api.DTO;

public partial class InsurancePolicyDTO
{
    public int Number { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public InsuranceCompanyDTO InsuranceCompany { get; set; } = null!;

    public InsurancePolicyDTO(InsurancePolicy insurancePolicy)
    {
        Number = insurancePolicy.Number;
        StartDate = insurancePolicy.StartDate;
        EndDate = insurancePolicy.EndDate;
        InsuranceCompany = new InsuranceCompanyDTO(insurancePolicy.InsuranceCompany);
    }
}
