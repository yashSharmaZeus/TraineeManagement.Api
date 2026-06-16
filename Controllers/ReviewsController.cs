using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
// [Authorize]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _ReviewsControllerService;
    private readonly ILogger<ReviewsController> _logger;
    public ReviewsController(IReviewService ReviewsControllerService, ILogger<ReviewsController> logger)
    {
        _ReviewsControllerService = ReviewsControllerService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<ReviewResponse> responses = await _ReviewsControllerService.GetAll();
        return Ok(responses);
    }

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
    [HttpPost]
    public async Task<IActionResult> AddNew(CreateReviewRequest request)
    {
        ReviewResponse response = await _ReviewsControllerService.AddNew(request);
        _logger.LogInformation("Review created successfully. TraineeId: {TraineeId}", response.Id);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

}