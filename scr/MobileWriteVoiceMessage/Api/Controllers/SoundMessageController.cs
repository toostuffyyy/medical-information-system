using Api.Context;
using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SoundMessageController : ControllerBase
{
    private readonly MyDbContext _dbContext;

    public SoundMessageController(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("AddSoundMessage")]
    public async Task<ActionResult> AddSoundMessage(IFormFile formFile)
    {
        string name = Guid.NewGuid().ToString() + ".3gp";
        string path = "SoundMessages/" + name;
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            await formFile.CopyToAsync(fileStream);
        }
        
        await _dbContext.SoundMessages.AddAsync(new SoundMessage(){NameFile = name});
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
    [HttpGet]
    [Route("GetSoundMessages")]
    public async Task<ActionResult<IEnumerable<SoundMessageDTO>>> GetSoundMessages()
    {
        var soundMessages = await _dbContext.SoundMessages.ToListAsync();
        return soundMessages.ConvertAll((p) => new SoundMessageDTO()
        {
            Id = p.Id,
            DateCreate = p.Date,
            Path = p.NameFile
        });
    }
    
}