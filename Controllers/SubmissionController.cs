using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/submissions")]
[Authorize]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionControllerService;
    private readonly ILogger<SubmissionController> _logger;
    public SubmissionController(ISubmissionService submissionControllerService, ILogger<SubmissionController> logger)
    {
        _submissionControllerService = submissionControllerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<SubmissionResponse> responses = await _submissionControllerService.GetAll();
        return Ok(responses);
    }

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
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateSubmissionRequest request)
    {
        SubmissionResponse response = await _submissionControllerService.AddNew(request);
        _logger.LogInformation("submission created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

}