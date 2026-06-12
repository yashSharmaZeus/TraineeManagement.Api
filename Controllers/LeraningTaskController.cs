using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[Authorize]
[ApiController]
[Route("/api/learning-tasks")]
public class LearningTasksController : ControllerBase
{
    private readonly ILogger<LearningTasksController> _logger;
    private readonly ILearningTaskService _iLearningTaskService;
    
    public LearningTasksController(ILearningTaskService iLearningTaskService,ILogger<LearningTasksController> logger)
    {
        _logger = logger;
        _iLearningTaskService = iLearningTaskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<LearningTaskResponse> response = await _iLearningTaskService.GetAll(requestParameter.search,requestParameter.pageNumber, requestParameter.pageSize,requestParameter.status);
        return Ok(response);
    }

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

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] CreateLearningTaskRequest request)
    {
        LearningTaskResponse response = await _iLearningTaskService.AddNew(request);
        _logger.LogInformation("Task created successfully, taskId: {Id}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

     [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMentor(int id, UpdateLearningTaskRequest request)
    {
        LearningTaskResponse? response = await _iLearningTaskService.UpdateTask(id, request);
        if (response == null)
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            return NotFound(new { message = $"Mentor with ID {id} not found" });
        }
        _logger.LogInformation("task updated successfully. taskId: {taskId}", id);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMentor(int id)
    {
        bool res = await _iLearningTaskService.DeleteTask(id);
        if (!res)
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            return NotFound(new { message = $"Mentor with ID {id} not found" });
        }
        _logger.LogInformation("Task deleted successfully. MentorId: {MentorId}", id);
        return NoContent();
    }
}
