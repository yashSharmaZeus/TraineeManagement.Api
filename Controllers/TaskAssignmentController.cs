using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/task-assignments")]
[Authorize]
public class TaskAssignmentController : ControllerBase
{
    private readonly ITaskAssignmentService _iTaskAssignmentService;
    private readonly ILogger<TaskAssignmentController> _logger;
    public TaskAssignmentController(ITaskAssignmentService iTaskAssignmentService, ILogger<TaskAssignmentController> logger)
    {
        _iTaskAssignmentService = iTaskAssignmentService;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<TaskAssignmentResponse> responses = await _iTaskAssignmentService.GetAll();
        return Ok(responses);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        TaskAssignmentResponse? response = await _iTaskAssignmentService.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("Task assignment with ID {id} not found", id);
            return NotFound(new { message = $"Task assignment with ID {id} not found" });
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddNew(CreateTaskAssignmentRequest request)
    {
        TaskAssignmentResponse response = await _iTaskAssignmentService.AddNew(request);
        _logger.LogInformation("task assignment created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateTrainee(int id, UpdateTaskAssignmentRequest request)
    {
        TaskAssignmentResponse? response = await _iTaskAssignmentService.Update(id, request);
        if (response == null)
        {
            _logger.LogInformation("Trainee with ID {id} not found", id);
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        _logger.LogInformation("Trainee updated successfully. TraineeId: {TraineeId}", id);
        return Ok(response);
    }
}
