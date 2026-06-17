using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _ReviewsControllerService;
    private readonly ILogger<ReviewsController> _logger;
    public ReviewsController(IReviewService ReviewsControllerService, ILogger<ReviewsController> logger)
    {
        _ReviewsControllerService = ReviewsControllerService;
        _logger = logger;
    }

    /// <summary>
    /// Retrieve all Review.
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    /// <response code="200">Retrieve all Review.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ReviewResponse> responses = await _ReviewsControllerService.GetAll();
        return Ok(responses);
    }

    /// <summary>
    /// Retrieve Review with matching ReviewId.
    /// </summary>
    /// <remarks> 
    ///  Authorization required
    /// </remarks>
    ///
    /// <param name="id">Review Id</param>
    /// <response code="200">Retrieve assigned task with matching ReviewId.</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        ReviewResponse? response = await _ReviewsControllerService.GetById(id);
        if (response == null)
        {
            _logger.LogInformation("Review with ID {id} not found", id);
            return NotFound(new { message = $"Review with ID {id} not found" });
        }
        return Ok(response);
    }

    /// <summary>
    /// Create new Review
    /// </summary>
    /// <remarks>
    /// Authorization required
    /// </remarks>
    ///
    /// <param name="request">ReviewId, ReviewUrl, Notes, SubmittedDate, ReviewStatus (Allowed value: Accepted, ChangesRequired, Rejected)</param>
    /// <response code="200">Create new Review and return it</response>
    /// <response code="401">If the user is not authenticated.</response>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateReviewRequest request)
    {
        ReviewResponse response = await _ReviewsControllerService.AddNew(request);
        _logger.LogInformation("Review created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
}