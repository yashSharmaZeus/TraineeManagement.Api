using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/processing-jobs")]
public class ProcessingJobController : ControllerBase
{
    private readonly ILogger<ProcessingJobController> _logger;
    private readonly IProcessingJobService _processingJobService;
    public ProcessingJobController(ILogger<ProcessingJobController> logger,IProcessingJobService processingJobService)
    {
        _logger = logger;
        _processingJobService = processingJobService;
    }

    /// <summary>
    /// Retrieve processing job with matching processing jobId.
    /// </summary>
    /// <remarks>  
    ///  Authorization required
    /// </remarks>
    ///
    /// <param name="id">processing job Id</param>
    /// <response code="200">Retrieve assigned task with matching processing jobId.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="404">If the data not found.</response>
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Id: {}",id);
        ProcessingJobResponse response = await _processingJobService.GetById(id);
        return Ok(response);
    }
}