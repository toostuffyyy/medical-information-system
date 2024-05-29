using Api.Context;
using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeMedicalEventController : ControllerBase
{
    [HttpGet("GetTypeMedicalEvent")]
    public async Task<ActionResult<TypeMedicalEventDTO>> GetTypeMedicalEvent()
    {
        var medicalEvent = await DatabaseContext.Context.TypeMedicalEvents.ToListAsync();
        return Ok(medicalEvent.ConvertAll(a => new TypeMedicalEventDTO(a)));
    }
}