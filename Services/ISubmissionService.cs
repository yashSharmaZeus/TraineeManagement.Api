using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ISubmissionService
{
    Task<List<SubmissionResponse>> GetAll();
    Task<SubmissionResponse?> GetById(int id);
    Task<SubmissionResponse> AddNew(CreateSubmissionRequest request);
}