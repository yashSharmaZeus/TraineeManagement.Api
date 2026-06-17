using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.controllers;

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


    /// <summary>
    /// Retrieves a paginated list of Mentors filtered by search keyword and status.
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Mentor** roles.
    /// </remarks>
    /// <param name="requestParameter">Pagination, filtering, and search parameters.</param>
    /// <response code="200">Returns a paginated list of Mentors matching the criteria.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Mentor role.</response>
    [Authorize(Roles = "Admin,Mentor")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<MentorResponse> response = await _iMentorService.GetAll(requestParameter.search, requestParameter.pageNumber, requestParameter.pageSize, requestParameter.status);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves a Mentor with given Id.
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Mentor** roles.
    /// </remarks>
    /// <param name="id">Mentor Id</param>
    /// <response code="200">Returns Mentor with matching Id.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Mentor role.</response>
    [Authorize(Roles = "Admin,Mentor")]
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

    /// <summary>
    /// Create new Mentor
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Mentor** roles.
    /// </remarks>
    ///
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values: Active, Inactive, Completed.) </param>
    /// <response code="200">Create new Mentor and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Mentor role.</response>
    // POST /api/mentors
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] CreateMentorRequest request)
    {
        MentorResponse response = await _iMentorService.AddNew(request);
        _logger.LogInformation("Mentor created successfully, MentorId: {MentorId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Update data of Mentor with matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">Mentor Id</param>
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values: Active, Inactive, Completed.) </param>
    /// <response code="200">Update Mentor and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Mentor")]
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

    /// <summary>
    /// Delete Mentor of matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">Mentor Id</param>
    /// <response code="200">Deletes Mentor.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
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