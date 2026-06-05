using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Models;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using Newtonsoft.Json.Serialization;
using TraineeManagement.Api.Services;
namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TraineesController : ControllerBase
{
     private ITraineeService _iTraineeServices;
    public TraineesController(ITraineeService iTraineeServices){
        _iTraineeServices = iTraineeServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_iTraineeServices.GetAll());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        TraineeResponse? response = _iTraineeServices.GetById(id);
        if (response == null)
        {
            return NotFound(new { message = $"Trainee with ID {id} not found" });
        }
        return Ok(response);
    }
    [HttpPost]
    public IActionResult AddNew(CreateTraineeRequest request)
    {
        TraineeResponse response = _iTraineeServices.AddNew(request);
        return StatusCode(201, response);
    }
}
