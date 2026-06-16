using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface IReviewService
{
    Task<List<ReviewResponse>> GetAll();
    Task<ReviewResponse?> GetById(int id);
    Task<ReviewResponse> AddNew(CreateReviewRequest request);
}