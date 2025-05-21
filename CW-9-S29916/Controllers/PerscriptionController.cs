using CW_9_S29916.DTOs;
using CW_9_S29916.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_S29916.Controllers;

[ApiController]
[Route("[controller]")]
public class PerscriptionController(DBService dbService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> PostPatientPerscription(PerscriptionPostDTO perscription)
    {
    throw new NotImplementedException();
    }
}