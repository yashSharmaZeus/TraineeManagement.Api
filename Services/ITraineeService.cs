using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ITraineeService
{
    List<TraineeResponse> GetAll();
    TraineeResponse? GetById(int id);
    TraineeResponse AddNew(CreateTraineeRequest request);
}