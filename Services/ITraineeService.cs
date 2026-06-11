using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ITraineeService
{
    Task<PagedResponse> GetAll(String? search,int pageNumber = 1,int pageSize = 10, string? status = null);
    Task<TraineeResponse?> GetById(int id);
    Task<TraineeResponse> AddNew(CreateTraineeRequest request);
    Task<TraineeResponse?> UpdateTrainee(int id,UpdateTraineeRequest request);
    Task<bool> DeleteTrainee(int id);
}