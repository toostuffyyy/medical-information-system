using System;

namespace MISMedicalCardMobile1.Models;

public class InsurancePolicy
{
    public int Number { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public InsuranceCompany InsuranceCompany { get; set; } = null!;
}