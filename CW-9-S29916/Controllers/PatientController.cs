using CW_9_S29916.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_S29916.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatientPerscriptionsAsync(int id)
    {
        throw new NotImplementedException();
    }
}