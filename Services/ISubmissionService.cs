using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface ISubmissionService
{
    Task<List<SubmissionResponse>> GetAll();
    Task<SubmissionResponse> GetById(int id);
    Task<SubmissionResponse> AddNew(CreateSubmissionRequest request);
    Task<SubmissionFileResponse> UploadFile(int userId,int SubmissionId, SubmissionFileRequest request);
    Task<FileStream> download(int id);
    Task<bool> delete(int id);
}