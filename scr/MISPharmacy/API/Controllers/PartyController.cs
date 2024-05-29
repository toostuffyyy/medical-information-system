using API.Context;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PartyController : ControllerBase
{
    [HttpPost("AddParty")]
    public async Task<ActionResult> AddParty(PartyDTO partyDto)
    {
        Party patient = new Party()
        {
            MedicationId = partyDto.MedicationId,
            SupplierId = partyDto.SupplierId,
            StorageId = partyDto.StorageId,
            ExpDate = partyDto.ExpDate,
            Amount = partyDto.Amount
        };
        try
        {
            await DataBaseContext.Context.Parties.AddAsync(patient);
            await DataBaseContext.Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("MovingStorage")]
    public async Task<ActionResult> MovingStorage(int olwPartyId, int newPartyId, int amount)
    {
        var oldParty = await DataBaseContext.Context.Parties.FirstOrDefaultAsync(a => a.Id == olwPartyId);
        var newParty = await DataBaseContext.Context.Parties.FirstOrDefaultAsync(a => a.Id == newPartyId);
        if (oldParty == null || newParty == null)
            return BadRequest();
        try
        {
            if (oldParty.Amount < amount)
                return BadRequest();
            oldParty.Amount -= amount;
            newParty.Amount += amount;
            await DataBaseContext.Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}