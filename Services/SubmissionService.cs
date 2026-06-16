using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Exceptions;


namespace TraineeManagement.Api.Services;

public class SubmissionService : ISubmissionService
{
    private readonly AppDbContext _context;
    public SubmissionService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<SubmissionResponse>> GetAll()
    {
        IQueryable<Submission> query = _context.Submission;
        List<SubmissionResponse> submissions = await query.Select(t => new SubmissionResponse(t)).ToListAsync();

        return submissions;
    }
    public async Task<SubmissionResponse?> GetById(int id)
    {
        Submission? submission = await _context.Submission.FindAsync(id);
        if (submission == null) return null;
        return new SubmissionResponse(submission);
    }

    public async Task<SubmissionResponse> AddNew(CreateSubmissionRequest request)
    {
        bool taskAssignmentExists = await _context.TaskAssignment.AnyAsync(t => t.Id == request.TaskAssignmentId);
        if (!taskAssignmentExists)throw new NotFoundException($"submission with submission: {request.TaskAssignmentId} does not exists");
        Submission taskAssignment = new Submission(request);

        await _context.Submission.AddAsync(taskAssignment);
        await _context.SaveChangesAsync();

        SubmissionResponse response = new SubmissionResponse(taskAssignment);
        return response;
    }
}