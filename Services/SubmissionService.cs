using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Exceptions;


namespace TraineeManagement.Api.Services;

public class SubmissionService : ISubmissionService
{
    private readonly AppDbContext _context;
    private readonly ILogger<SubmissionService> _logger;
    public SubmissionService(AppDbContext context, ILogger<SubmissionService> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<SubmissionResponse>> GetAll()
    {
        IQueryable<Submission> query = _context.Submission;
        List<SubmissionResponse> submissions = await query.Select(t => new SubmissionResponse(t)).ToListAsync();

        return submissions;
    }
    public async Task<SubmissionResponse> GetById(int id)
    {
        Submission? submission = await _context.Submission.FindAsync(id);
        if (submission == null)
        {
            _logger.LogInformation("submission with ID {id} not found", id);
            throw new NotFoundException($"submission with ID {id} not found");
        }
        return new SubmissionResponse(submission);
    }

    public async Task<SubmissionResponse> AddNew(CreateSubmissionRequest request)
    {
        bool taskAssignmentExists = await _context.TaskAssignment.AnyAsync(t => t.Id == request.TaskAssignmentId);
        if (!taskAssignmentExists)
        {
            _logger.LogInformation("Task assignment with Task assignment Id: {Id} does not exists",request.TaskAssignmentId);
            throw new NotFoundException($"Task assignment with Task assignment Id: {request.TaskAssignmentId} does not exists");
        }
        Submission taskAssignment = new Submission(request);

        await _context.Submission.AddAsync(taskAssignment);
        await _context.SaveChangesAsync();
        SubmissionResponse response = new SubmissionResponse(taskAssignment);
        return response;
    }
}