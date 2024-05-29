using API.Context;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class StorageController : ControllerBase
{
    [HttpGet("GetStorage")]
    public async Task<ActionResult<List<StorageDTO>>> GetStorage()
    {
        var storage = await DataBaseContext.Context.Storages.ToListAsync();
        if (storage == null)
            return null;
        return Ok(storage.ConvertAll(a => new StorageDTO(a)));
    }
}