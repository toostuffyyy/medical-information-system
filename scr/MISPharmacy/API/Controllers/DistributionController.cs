using API.Context;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DistributionController : ControllerBase
{
    [HttpGet("GetDistribution")]
    public async Task<ActionResult<List<DistributionDTO>>> GetDistribution()
    {
        var distribution = await DataBaseContext.Context.Distributions.ToListAsync();
        if (distribution == null)
            return BadRequest();
        return Ok(distribution.ConvertAll(a => new DistributionDTO(a)));
    }
    
    [HttpPut("UpdateDistribution")]
    public async Task<ActionResult> UpdateDistribution(DistributionDTO distributionDto)
    {
        var distribution =
            await DataBaseContext.Context.Distributions.FirstOrDefaultAsync(a => a.Id == distributionDto.Id);
        var party = await DataBaseContext.Context.Parties.FirstOrDefaultAsync(a => a.MedicationId == distribution.MedicationId 
        && a.StorageId == distribution.StorageId && a.SupplierId == distributionDto.StorageId);

        if (distribution == null || party == null)
            return BadRequest();
        try
        {
            distribution.IsApproved = true;
            if (party.Amount > distribution.Amount)
                party.Amount -= distribution.Amount;
            await DataBaseContext.Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}