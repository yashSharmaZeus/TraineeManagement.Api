using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/submissions")]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionControllerService;
    private readonly ILogger<SubmissionController> _logger;
    public SubmissionController(ISubmissionService submissionControllerService, ILogger<SubmissionController> logger)
    {
        _submissionControllerService = submissionControllerService;
        _logger = logger;
    }

    /// <summary>
    /// Retrieve all Submission.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <response code="200">Retrieve all Submission.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<SubmissionResponse> responses = await _submissionControllerService.GetAll();
        return Ok(responses);
    }


    /// <summary>
    /// Retrieve Submission with matching SubmissionId.
    /// </summary>
    /// <remarks>   ]
    ///  Authorization required
    /// </remarks>
    ///
    /// <param name="id">Submission Id</param>
    /// <response code="200">Retrieve assigned task with matching SubmissionId.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        SubmissionResponse? response = await _submissionControllerService.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("submission with ID {id} not found", id);
            return NotFound(new { message = $"submission with ID {id} not found" });
        }
        return Ok(response);
    }


    /// <summary>
    /// Create new Submission
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    ///
    /// <param name="request">SubmissionId, SubmissionUrl, Notes, SubmittedDate, Status (Allowed value: Submitted, Resubmitted)</param>
    /// <response code="200">Create new Submission and return it</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateSubmissionRequest request)
    {
        SubmissionResponse response = await _submissionControllerService.AddNew(request);
        _logger.LogInformation("submission created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

}