using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ITaskAssignmentService
{
    Task<List<TaskAssignmentResponse>> GetAll();
    Task<TaskAssignmentResponse> GetById(int id);
    Task<TaskAssignmentResponse> AddNew(CreateTaskAssignmentRequest request);
    Task<TaskAssignmentResponse> Update(int id, UpdateTaskAssignmentRequest request);
}