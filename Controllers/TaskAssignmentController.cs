using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/task-assignments")]
public class TaskAssignmentController : ControllerBase
{
    private readonly ITaskAssignmentService _iTaskAssignmentService;
    private readonly ILogger<TaskAssignmentController> _logger;
    public TaskAssignmentController(ITaskAssignmentService iTaskAssignmentService, ILogger<TaskAssignmentController> logger)
    {
        _iTaskAssignmentService = iTaskAssignmentService;
        _logger = logger;
    }

    /// <summary>
    /// Retrieve all assigned task.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <response code="200">Retrieve all assigned task.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<TaskAssignmentResponse> responses = await _iTaskAssignmentService.GetAll();
        return Ok(responses);
    }

    /// <summary>
    /// Retrieve assigned task with matching TaskAssignmentId.
    /// </summary>
    /// <remarks>   ]
    ///  Authorization required
    /// </remarks>
    ///
    /// <param name="id">TaskAssignment Id</param>
    /// <response code="200">Retrieve assigned task with matching TaskAssignmentId.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
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

    /// <summary>
    /// Create new TaskAssignment
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    ///
    /// <param name="request">TraineeId, MentorId, LearningTaskId, AssignedDate, DueDate, Status (allowed Value:  Assigned, InProgress, Submitted, Reviewed, Completed), Remarks</param>
    /// <response code="200">Create new TaskAssignment and return it</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateTaskAssignmentRequest request)
    {
        TaskAssignmentResponse response = await _iTaskAssignmentService.AddNew(request);
        _logger.LogInformation("task assignment created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Create new TaskAssignment
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    ///
    /// <param name="id">TaskAssignment Id</param>
    /// <param name="request">Status(allowed Value:  Assigned, InProgress, Submitted, Reviewed, Completed)</param>
    /// <response code="200">Create new TaskAssignment and return it</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpPut("{id:int}/status")]
    public async Task<IActionResult> UpdateTaskAssignment(int id, UpdateTaskAssignmentRequest request)
    {
        TaskAssignmentResponse? response = await _iTaskAssignmentService.Update(id, request);
        if (response == null)
        {
            _logger.LogInformation("Task Assignment with ID {id} not found", id);
            return NotFound(new { message = $"Task Assignment with ID {id} not found" });
        }
        _logger.LogInformation("Task Assignment updated successfully. TaskAssignmentID: {TaskAssignmentID}", id);
        return Ok(response);
    }
}
