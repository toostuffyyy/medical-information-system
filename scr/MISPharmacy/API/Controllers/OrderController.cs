using API.Context;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost("AddOrder")]
    public async Task<ActionResult> AddOrder(OrderDTO orderDto)
    {
        var order = new Order()
        {
            MedicationId = orderDto.MedicationId,
            SupplierId = orderDto.SupplierId,
            StorageId = orderDto.StorageId,
            Date = orderDto.Date,
            Amount = orderDto.Amount
        };
        try
        {
            await DataBaseContext.Context.Orders.AddAsync(order);
            await DataBaseContext.Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}