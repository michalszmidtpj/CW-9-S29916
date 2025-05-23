using CW_9_S29916.DTOs;
using CW_9_S29916.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_S29916.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController(IDbService service) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientPerscriptionsAsync([FromRoute] int id)
    {
        PatientPerscriptionDTO result;
        try
        {
            result = await service.GetPatientPrescriptionsAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
           BadRequest(e.Message);
        }
        return BadRequest();
    }
}