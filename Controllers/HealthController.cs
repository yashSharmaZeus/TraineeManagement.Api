using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(
            new
            {
                status = "running",
                application = "Trainee Management API",
                timestamp = DateHelper.Now(),
            });
    }
}
