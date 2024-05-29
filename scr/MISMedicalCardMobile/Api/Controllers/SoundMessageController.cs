using Api.Context;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SoundMessageController : ControllerBase
{
    [HttpPost("AddSoundMessage")]
    public async Task<ActionResult> AddSoundMessage(IFormFile formFile)
    {
        string name = Guid.NewGuid() + ".3gp";
        string path = "SoundMessage/" + name;
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
            await formFile.CopyToAsync(fileStream);

        await DatabaseContext.Context.SoundMessages.AddAsync(new SoundMessage() { Name = name });
        await DatabaseContext.Context.SaveChangesAsync();
        return Ok();
    }
}