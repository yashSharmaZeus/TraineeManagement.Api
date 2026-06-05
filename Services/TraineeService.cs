using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public class TraineeService: ITraineeService
{
    public List<TraineeResponse> GetAll()
    {
        List<TraineeResponse> response = TraineeStore.trainees.Select(t => new TraineeResponse
        {
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            TechStack = t.TechStack,
            Status = t.Status,
            IsComplete = t.IsComplete,
            CreatedDate = t.CreatedDate,
            UpdatedDate = t.UpdatedDate,
        }).ToList();
        return response;
    }

    public TraineeResponse? GetById(int id)
    {
        Trainee? trainee = TraineeStore.trainees.Find(t => t.Id == id);
        if (trainee == null)
        {
            return null;
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
        return response;
    }

    public TraineeResponse AddNew(CreateTraineeRequest request)
    {
        Trainee trainee = new Trainee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            TechStack = request.TechStack,
            Status = request.Status,
        };
        trainee.Id = TraineeStore.trainees.Count > 0 ? TraineeStore.trainees.Max(t => t.Id) + 1 : 1;
        trainee.CreatedDate = DateTime.Now;
        trainee.UpdatedDate = DateTime.Now;
        trainee.IsComplete = false;
        TraineeStore.trainees.Add(trainee);

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
        return response;
    }

}