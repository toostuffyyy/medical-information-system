using API.Context;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : ControllerBase
{
    [HttpGet("GetSupplier")]
    public async Task<ActionResult<List<SupplierDTO>>> GetSupplier()
    {
        var sup = await DataBaseContext.Context.Suppliers.ToListAsync();
        if (sup == null)
            return null;
        return Ok(sup.ConvertAll(a => new SupplierDTO(a)));
    }
}