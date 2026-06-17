using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/learning-tasks")]
public class LearningTasksController : ControllerBase
{
    private readonly ILogger<LearningTasksController> _logger;
    private readonly ILearningTaskService _iLearningTaskService;

    public LearningTasksController(ILearningTaskService iLearningTaskService, ILogger<LearningTasksController> logger)
    {
        _logger = logger;
        _iLearningTaskService = iLearningTaskService;
    }

    /// <summary>
    /// Retrieves a paginated list of LearningTask filtered by search keyword and status.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <param name="requestParameter">Pagination, filtering, and search parameters.</param>
    /// <response code="200">Returns a paginated list of LearningTask matching the criteria.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<LearningTaskResponse> response = await _iLearningTaskService.GetAll(requestParameter.search, requestParameter.pageNumber, requestParameter.pageSize, requestParameter.status);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves a learningTask with given Id.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <param name="id">learningTask Id</param>
    /// <response code="200">Returns learningTask with matching Id.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        LearningTaskResponse? response = await _iLearningTaskService.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            return NotFound(new { message = $"Task with ID {id} not found" });
        }
        return Ok(response);
    }

    /// <summary>
    /// Create new learningTask
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    ///
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values:  Draft, Published, Closed.) </param>
    /// <response code="200">Create new learningTask and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] CreateLearningTaskRequest request)
    {
        LearningTaskResponse response = await _iLearningTaskService.AddNew(request);
        _logger.LogInformation("Task created successfully, taskId: {Id}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Update data of learningTask with matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">learningTask Id</param>
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values: Active, Inactive, Completed.) </param>
    /// <response code="200">Update learningTask and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>
    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLearningTask(int id, UpdateLearningTaskRequest request)
    {
        LearningTaskResponse? response = await _iLearningTaskService.UpdateTask(id, request);
        if (response == null)
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            return NotFound(new { message = $"learningTask with ID {id} not found" });
        }
        _logger.LogInformation("task updated successfully. taskId: {taskId}", id);
        return Ok(response);
    }

    /// <summary>
    /// Delete learningTask of matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">learningTask Id</param>
    /// <response code="200">Deletes learningTask.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>
    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLearningTask(int id)
    {
        bool res = await _iLearningTaskService.DeleteTask(id);
        if (!res)
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            return NotFound(new { message = $"learningTask with ID {id} not found" });
        }
        _logger.LogInformation("Task deleted successfully. learningTaskId: {learningTaskId}", id);
        return NoContent();
    }
}
