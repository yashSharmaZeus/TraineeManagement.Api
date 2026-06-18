using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Exceptions;


namespace TraineeManagement.Api.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;
    private readonly ILogger<ReviewService> _logger;
    public ReviewService(AppDbContext context, ILogger<ReviewService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<ReviewResponse>> GetAll()
    {
        IQueryable<Review> query = _context.Review;
        List<ReviewResponse> Reviews = await query.Select(t => new ReviewResponse(t)).ToListAsync();

        return Reviews;
    }
    public async Task<ReviewResponse> GetById(int id)
    {
        Review? Review = await _context.Review.FindAsync(id);
        if (Review == null)
        {
            _logger.LogInformation("Review with id:{id} not found", id);
            throw new NotFoundException($"Review with id:{id} not found");
        }
        return new ReviewResponse(Review);
    }

    public async Task<ReviewResponse> AddNew(CreateReviewRequest request)
    {
        bool SubmissionIdExists = await _context.Submission.AnyAsync(t => t.Id == request.SubmissionId);
        if (!SubmissionIdExists)
        {
            _logger.LogInformation("submission with Id: {id} not found", request.SubmissionId);
            throw new NotFoundException($"submission with submission Id: {request.SubmissionId} does not exists");
        }
        bool MentorIdExists = await _context.Mentors.AnyAsync(t => t.Id == request.MentorId);
        if (!MentorIdExists)
        {
            _logger.LogInformation("mentor with Id: {id} not found", request.MentorId);
            throw new NotFoundException($"Mentor with Mentor Id: {request.MentorId} does not exists");
        }

        Review SubmissionId = new Review(request);

        await _context.Review.AddAsync(SubmissionId);
        await _context.SaveChangesAsync();

        ReviewResponse response = new ReviewResponse(SubmissionId);
        return response;
    }
}