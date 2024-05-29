using Api.Context;
using Api.DTO;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="patientDto"></param>
    /// <returns></returns>
    [HttpPut("UpdatePatient")]
    public async Task<ActionResult> UpdatePatient(PatientDTO patientDto)
    {
        try
        {
            var patient = new Patient()
            {
                PassportNumber = patientDto.PassportNumber,
                PassportSeries = patientDto.PassportSeries,
                Surname = patientDto.Surname,
                Name = patientDto.Name,
                Patronymic = patientDto.Patronymic,
                DateOfBirth = patientDto.DateOfBirth,
                Address = patientDto.Address,
                PlaceOfWork = patientDto.PlaceOfWork,
                PhoneNumber = patientDto.PhoneNumber,
                Email = patientDto.Email,
                Photo = patientDto.Photo
            };
            DatabaseContext.Context.Patients.Update(patient);
            await DatabaseContext.Context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            ModelState.AddModelError("DBUpdate", e.Message);
            return BadRequest(ModelState);
        }
    }
}