using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ITraineeService
{
    Task<List<TraineeResponse>> GetAll(String? search);
    Task<TraineeResponse?> GetById(int id);
    Task<TraineeResponse> AddNew(CreateTraineeRequest request);
    Task<TraineeResponse?> UpdateTrainee(int id,UpdateTraineeRequest request);
    Task<bool> DeleteTrainee(int id);
}