using API.Context;
using API.DTO;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    [HttpGet("GetMedication")]
    public async Task<ActionResult<MedicationDTO>> GetMedication()
    {
        var medication = await DataBaseContext.Context.Medications
            .Include(a => a.Parties)
            .ThenInclude(a => a.Storage)
            .Include(a => a.Parties)
            .ThenInclude(a => a.Supplier)
            .ToListAsync();
        if (medication == null)
            return BadRequest();
        return Ok(medication.Select(a => new MedicationDTO(a)));
    }
}