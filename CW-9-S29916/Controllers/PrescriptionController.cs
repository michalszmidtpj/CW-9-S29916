using CW_9_S29916.DTOs;
using CW_9_S29916.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_S29916.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService dbService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostPatientPerscription([FromBody] PerscriptionPostDTO prescription)
    {
        int id = prescription.IdPatient;
        try
        {
            id = await dbService.PostPrescriptionAsync(prescription);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok(id);
    }
}