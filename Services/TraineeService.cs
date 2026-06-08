using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public class TraineeService : ITraineeService
{
    public List<TraineeResponse> GetAll()
    {
        List<TraineeResponse> response = TraineeStore.trainees.Select(t => new TraineeResponse(t)).ToList();
        return response;
    }

    public TraineeResponse? GetById(int id)
    {
        Trainee? trainee = TraineeStore.trainees.Find(t => t.Id == id);
        if (trainee == null)
        {
            return null;
        }
        TraineeResponse response = new TraineeResponse(trainee);
        return response;
    }

    public TraineeResponse AddNew(CreateTraineeRequest request)
    {
        Trainee trainee = new Trainee
        {   Id = TraineeStore.GetNextId(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            TechStack = request.TechStack,
            Status = request.Status,
        };
        TraineeStore.trainees.Add(trainee);

        TraineeResponse response = new TraineeResponse(trainee);
        return response;
    }

    public TraineeResponse? UpdateTrainee(int id, UpdateTraineeRequest request)
    {
        Trainee? trainee = TraineeStore.trainees.Find(t => t.Id == id);
        if (trainee == null) return null;
        trainee.FirstName = request.FirstName;
        trainee.LastName = request.LastName;
        trainee.Email = request.Email;
        trainee.TechStack = request.TechStack;
        trainee.Status = request.Status;
        trainee.UpdatedDate = DateTime.Now;
        return GetById(id);
    }

    public bool DeleteTrainee(int id)
    {
        Trainee? trainee = TraineeStore.trainees.Find(t => t.Id == id);
        if (trainee == null) return false;
        TraineeStore.trainees.Remove(trainee);
        return true;
    }
}