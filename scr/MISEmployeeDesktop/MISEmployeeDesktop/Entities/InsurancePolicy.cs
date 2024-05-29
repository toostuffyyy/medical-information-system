using System;

namespace MISEmployeeDesktop.Entities;

public partial class InsurancePolicy
{
    public int Number { get; set; }

    public int InsuranceCompanyId { get; set; }

    public int PatientId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual InsuranceCompany InsuranceCompany { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
