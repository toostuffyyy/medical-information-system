using Api.Context;
using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GenderController : ControllerBase
{
    [HttpGet("GetGender")]
    public async Task<ActionResult<GenderDTO>> GetGender()
    {
        var genders = await DatabaseContext.Context.Genders.ToListAsync();
        return Ok(genders.ConvertAll(a => new GenderDTO(a)));
    }
}