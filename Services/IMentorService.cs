using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface IMentorService
{
    Task<PagedResponse<MentorResponse>> GetAll(string? search,int pageNumber = 1,int pageSize = 10, string? status = null);
    Task<MentorResponse?> GetById(int id);
    Task<MentorResponse> AddNew(CreateMentorRequest request);
    Task<MentorResponse?> UpdateMentor(int id,UpdateMentorRequest request);
    Task<bool> DeleteMentor(int id);
}