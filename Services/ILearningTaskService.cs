using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ILearningTaskService
{
    Task<PagedResponse<LearningTaskResponse>> GetAll(string? search,int pageNumber = 1,int pageSize = 10, string? status = null);
    Task<LearningTaskResponse?> GetById(int id);
    Task<LearningTaskResponse> AddNew(CreateLearningTaskRequest request);
    Task<LearningTaskResponse?> UpdateTask(int id,UpdateLearningTaskRequest request);
    Task<bool> DeleteTask(int id);
}