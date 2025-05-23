using CW_9_S29916.DTOs;
using CW_9_S29916.Exceptions;
using CW_9_S29916.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_S29916.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionController(IDbService dbService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> PostPatientPerscription(PerscriptionPostDTO prescription)
    {
        try
        {
            await dbService.PostPrescriptionAsync(prescription);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }


        return Ok();

    }
}