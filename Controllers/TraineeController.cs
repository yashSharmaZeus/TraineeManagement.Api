using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TraineeManagement.Api.Models;
using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TraineesController : ControllerBase
{
    public static List<Trainee> trainees = [];

    [HttpGet]
    public IActionResult GetAll()
    {
        var response = trainees.Select(t => new TraineeResponse
        {
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            TechStack = t.TechStack,
            Status = t.Status,
            IsComplete = t.IsComplete,
            CreatedDate = t.CreatedDate,
            UpdatedDate = t.UpdatedDate,
        });
        return Ok(response);
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        Trainee? trainee = trainees.Find(t => t.Id == id);
        if (trainee == null)
        {
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        TraineeResponse response = new TraineeResponse
        {
            FirstName = trainee.FirstName,
            LastName = trainee.LastName,
            Email = trainee.Email,
            TechStack = trainee.TechStack,
            Status = trainee.Status,
            IsComplete = trainee.IsComplete,
            CreatedDate = trainee.CreatedDate,
            UpdatedDate = trainee.UpdatedDate,
        };
        return Ok(response);
    }
    [HttpPost]
    public IActionResult AddNew(CreateTraineeRequest request)
    {
        Trainee trainee = new Trainee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            TechStack = request.TechStack,
            Status = request.Status,
        };
        trainee.Id = trainees.Count > 0 ? trainees.Max(t => t.Id) + 1 : 1;
        trainee.CreatedDate = DateTime.Now;
        trainee.UpdatedDate = DateTime.Now;
        trainee.IsComplete = false;
        trainees.Add(trainee);

        TraineeResponse response = new TraineeResponse
        {
            FirstName = trainee.FirstName,
            LastName = trainee.LastName,
            Email = trainee.Email,
            TechStack = trainee.TechStack,
            Status = trainee.Status,
            IsComplete = trainee.IsComplete,
            CreatedDate = trainee.CreatedDate,
            UpdatedDate = trainee.UpdatedDate,
        };
        return CreatedAtAction(nameof(GetById), new { id = trainee.Id }, response);
    }
}
