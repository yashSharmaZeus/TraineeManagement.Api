using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class TraineesController : ControllerBase
{
    private readonly ITraineeService _iTraineeServices;
    private readonly ILogger<TraineesController> _logger;
    public TraineesController(ITraineeService iTraineeServices, ILogger<TraineesController> logger)
    {
        _iTraineeServices = iTraineeServices;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<TraineeResponse> response = await _iTraineeServices.GetAll(requestParameter.search, requestParameter.pageNumber, requestParameter.pageSize, requestParameter.status);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        TraineeResponse? response = await _iTraineeServices.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("Trainee with ID {id} not found", id);
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddNew(CreateTraineeRequest request)
    {
        TraineeResponse response = await _iTraineeServices.AddNew(request);
        _logger.LogInformation("Trainee created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTrainee(int id, UpdateTraineeRequest request)
    {
        TraineeResponse? response = await _iTraineeServices.UpdateTrainee(id, request);
        if (response == null)
        {
            _logger.LogInformation("Trainee with ID {id} not found", id);
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        _logger.LogInformation("Trainee updated successfully. TraineeId: {TraineeId}", id);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTrainee(int id)
    {
        bool res = await _iTraineeServices.DeleteTrainee(id);
        if (!res)
        {
            _logger.LogInformation("Trainee with ID {id} not found", id);
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        _logger.LogInformation("Trainee deleted successfully. TraineeId: {TraineeId}",id);
        return NoContent();
    }
}
