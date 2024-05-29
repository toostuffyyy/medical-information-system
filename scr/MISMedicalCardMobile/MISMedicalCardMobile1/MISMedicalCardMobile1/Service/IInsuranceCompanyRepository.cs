using System.Collections.Generic;
using System.Threading.Tasks;
using MISMedicalCardMobile1.Models;
using Refit;

namespace MISMedicalCardMobile1.Service;

public interface IInsuranceCompanyRepository
{
    [Get("/InsuranceCompany/GetInsuranceCompany")]
    public Task<IEnumerable<InsuranceCompany>> GetInsuranceCompany();
}