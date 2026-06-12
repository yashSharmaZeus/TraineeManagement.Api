using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class MentorsController : ControllerBase
{
    private readonly ILogger<MentorsController> _logger;
    private readonly IMentorService _iMentorService;

    public MentorsController(IMentorService iMentorService, ILogger<MentorsController> logger)
    {
        _iMentorService = iMentorService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<MentorResponse> response = await _iMentorService.GetAll(requestParameter.search, requestParameter.pageNumber, requestParameter.pageSize, requestParameter.status);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        MentorResponse? response = await _iMentorService.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("Mentor with ID {id} not found", id);
            return NotFound(new { message = $"mentor with ID {id} not found" });
        }
        return Ok(response);
    }

    // POST /api/mentors
    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] CreateMentorRequest request)
    {
        MentorResponse response = await _iMentorService.AddNew(request);
        _logger.LogInformation("Mentor created successfully, MentorId: {MentorId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMentor(int id, UpdateMentorRequest request)
    {
        MentorResponse? response = await _iMentorService.UpdateMentor(id, request);
        if (response == null)
        {
            _logger.LogInformation("Mentor with ID {id} not found", id);
            return NotFound(new { message = $"Mentor with ID {id} not found" });
        }
        _logger.LogInformation("Mentor updated successfully. MentorId: {MentorId}", id);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMentor(int id)
    {
        bool res = await _iMentorService.DeleteMentor(id);
        if (!res)
        {
            _logger.LogInformation("Mentor with ID {id} not found", id);
            return NotFound(new { message = $"Mentor with ID {id} not found" });
        }
        _logger.LogInformation("Mentor deleted successfully. MentorId: {MentorId}", id);
        return NoContent();
    }
}