using Api.Context;
using Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalCardController : ControllerBase
{
    /// <summary>
    /// Отправка мед.карты по ее номеру.
    /// </summary>
    /// <param name="number">Номер мед. карты</param>
    /// <returns></returns>
    [HttpGet("GetMedicalCart")]
    public async Task<ActionResult<MedicalCardDTO>> GetMedicalCart(int number)
    {
        var medicalCard = await DatabaseContext.Context.MedicalCards
            .Include(a => a.Patient)
            .ThenInclude(a => a.Gender)
            .Include(a => a.Patient)
            .ThenInclude(a => a.InsurancePolicies)
            .ThenInclude(a => a.InsuranceCompany)
            .FirstOrDefaultAsync(a => a.Number == number);
        
        return Ok(new MedicalCardDTO(medicalCard));
    }
}