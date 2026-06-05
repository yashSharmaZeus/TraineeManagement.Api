using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TraineesController : ControllerBase
{   
    public static List<Trainee> trainees = [];

    [HttpGet]
    public IActionResult GetAll()
    {   
        return Ok(trainees);
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        Trainee? trainee = trainees.Find(t=>t.Id==id);
        if (trainee == null)
        {
            return NotFound(new {message = $"Trainee with ID {id} not found"});
        }
        return Ok(trainee);
  }
    [HttpPost]
    public IActionResult AddNew(Trainee trainee)
    {
        trainee.Id = trainees.Count > 0 ? trainees.Max(t=>t.Id)+1:1;
        trainee.CreatedDate = DateTime.Now;
        trainee.UpdatedDate = DateTime.Now;
        trainees.Add(trainee);
        return CreatedAtAction(nameof(GetById), new { id = trainee.Id}, trainee);
    }
}
