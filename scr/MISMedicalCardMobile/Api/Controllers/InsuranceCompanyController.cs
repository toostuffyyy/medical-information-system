using Api.Context;
using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceCompanyController : ControllerBase
{
    [HttpGet("GetInsuranceCompany")]
    public async Task<ActionResult<InsuranceCompanyDTO>> GetInsuranceCompany()
    {
        var insuranceCom = await DatabaseContext.Context.InsuranceCompanies.ToListAsync();
        return Ok(insuranceCom.ConvertAll(a => new InsuranceCompanyDTO(a)));
    }
}