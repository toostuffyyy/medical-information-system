using API.Context;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartamentController : ControllerBase
{
    [HttpGet("GetSupplier")]
    public async Task<ActionResult<List<DepartamentDTO>>> GetSupplier()
    {
        var departaments = await DataBaseContext.Context.Departaments.ToListAsync();
        if (departaments == null)
            return null;
        return Ok(departaments.ConvertAll(a => new DepartamentDTO(a)));
    }
}