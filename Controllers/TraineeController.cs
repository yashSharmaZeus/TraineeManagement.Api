using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TraineesController : ControllerBase
{
    private ITraineeService _iTraineeServices;
    public TraineesController(ITraineeService iTraineeServices)
    {
        _iTraineeServices = iTraineeServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? search = null)
    {   List<TraineeResponse> res = await _iTraineeServices.GetAll(search);
        return Ok(res);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        TraineeResponse? response = await _iTraineeServices.GetById(id);
        if (response == null)
        {
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        return Ok(response); 
    }

    [HttpPost]
    public async Task<IActionResult> AddNew(CreateTraineeRequest request)
    {
        TraineeResponse response = await _iTraineeServices.AddNew(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTrainee(int id, UpdateTraineeRequest request)
    {
        TraineeResponse? response = await _iTraineeServices.UpdateTrainee(id, request);
        if (response == null) return NotFound(new { message = $"Trainee with ID {id} not found" });
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTrainee(int id)
    {
        bool res = await _iTraineeServices.DeleteTrainee(id);
        return res ? NoContent() : NotFound(new { message = $"Trainee with ID {id} not found" });
    }
}
