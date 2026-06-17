using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

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

    /// <summary>
    /// Retrieves a paginated list of trainees filtered by search keyword and status.
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Trainee** roles.
    /// </remarks>
    /// <param name="requestParameter">Pagination, filtering, and search parameters.</param>
    /// <response code="200">Returns a paginated list of trainees matching the criteria.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Trainee role.</response>

    [Authorize(Roles = "Admin,Trainee")]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchRequestParameter requestParameter)
    {
        PagedResponse<TraineeResponse> response = await _iTraineeServices.GetAll(requestParameter.search, requestParameter.pageNumber, requestParameter.pageSize, requestParameter.status);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves a Trainee with given Id.
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Trainee** roles.
    /// </remarks>
    /// <param name="id">Trainee Id</param>
    /// <response code="200">Returns Trainee with matching Id.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Trainee role.</response>

    [Authorize(Roles = "Admin,Trainee")]
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


    /// <summary>
    /// Create new Trainee
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** and **Trainee** roles.
    /// </remarks>
    ///
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values: Active, Inactive, Completed.) </param>
    /// <response code="200">Create new trainee and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin or Trainee role.</response>

    [Authorize(Roles = "Admin,Trainee")]
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateTraineeRequest request)
    {
        TraineeResponse response = await _iTraineeServices.AddNew(request);
        _logger.LogInformation("Trainee created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Update data of Trainee with matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">Trainee Id</param>
    /// <param name="request">First name, Last name, Email, TechStack and status ( Allowed values: Active, Inactive, Completed.) </param>
    /// <response code="200">Update trainee and return it.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>
    [Authorize(Roles = "Admin")]
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

    
    /// <summary>
    /// Delete Trainee of matching id
    /// </summary>
    /// <remarks>
    /// Accessible only by **Admin** roles.
    /// </remarks>
    ///
    /// <param name="id">Trainee Id</param>
    /// <response code="200">Deletes trainee.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user does not have the Admin role.</response>

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTrainee(int id)
    {
        bool res = await _iTraineeServices.DeleteTrainee(id);
        if (!res)
        {
            _logger.LogInformation("Trainee with ID {id} not found", id);
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        _logger.LogInformation("Trainee deleted successfully. TraineeId: {TraineeId}", id);
        return NoContent();
    }
}
