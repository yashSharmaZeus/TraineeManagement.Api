using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Exceptions;

namespace TraineeManagement.Api.Services;

public class TaskAssignmentService : ITaskAssignmentService
{
    private readonly AppDbContext _context;
    private readonly ILogger<TaskAssignment> _logger;
    public TaskAssignmentService(AppDbContext context, ILogger<TaskAssignment> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<TaskAssignmentResponse>> GetAll()
    {
        IQueryable<TaskAssignment> query = _context.TaskAssignment;
        List<TaskAssignmentResponse> taskAssignments = await query.Select(t => new TaskAssignmentResponse(t)).ToListAsync();

        return taskAssignments;
    }
    public async Task<TaskAssignmentResponse> GetById(int id)
    {
        TaskAssignment? taskAssignment = await _context.TaskAssignment.FindAsync(id);
        if (taskAssignment == null)
        {
            _logger.LogInformation($"Task assignment with ID {id} not found");
            throw new NotFoundException($"Task assignment with ID {id} not found");
        }
        
        return new TaskAssignmentResponse(taskAssignment);
    }

    public async Task<TaskAssignmentResponse> AddNew(CreateTaskAssignmentRequest request)
    {
        bool TraineeExists = await _context.Trainees.AnyAsync(t => t.Id == request.TraineeId);
        if (!TraineeExists)
        {
            _logger.LogInformation("Trainee with TraineeId: {id} does not exists",request.TraineeId);
            throw new NotFoundException($"Trainee with TraineeId: {request.TraineeId} does not exists");
        }
        bool MentorExists = await _context.Trainees.AnyAsync(t => t.Id == request.MentorId);
        if (!MentorExists)
        {
            _logger.LogInformation("Mentor with MentorId: {id} does not exists",request.MentorId);
            throw new NotFoundException($"Mentor with MentorId: {request.MentorId} does not exists");
        }
        bool LearningTaskExists = await _context.Trainees.AnyAsync(t => t.Id == request.LearningTaskId);
        if (!LearningTaskExists)
        {
            _logger.LogInformation("Learning task with LearningTaskId: {id} does not exists",request.LearningTaskId);
            throw new NotFoundException($"Learning task with LearningTaskId: {request.LearningTaskId} does not exists");
        }

        if (request.AssignedDate < request.DueDate) throw new NotFoundException("DueDate should not be before AssignedDate");
        TaskAssignment taskAssignment = new TaskAssignment(request);

        await _context.TaskAssignment.AddAsync(taskAssignment);
        await _context.SaveChangesAsync();

        TaskAssignmentResponse response = new TaskAssignmentResponse(taskAssignment);
        return response;
    }
    public async Task<TaskAssignmentResponse> Update(int id, UpdateTaskAssignmentRequest request)
    {
        TaskAssignment? taskAssignment = await _context.TaskAssignment.FindAsync(id);
        if(taskAssignment == null)
        {
            _logger.LogInformation("Task assignment with ID {id} not found",id);
            throw new NotFoundException($"Task assignment with ID {id} not found");
        };
        taskAssignment.Status = request.Status;
        await _context.SaveChangesAsync();
        return await GetById(id);
    }
}