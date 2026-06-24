using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface IProcessingJobService
{
    Task<ProcessingJobResponse> GetById(int id);
}