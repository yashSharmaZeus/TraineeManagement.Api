using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Helpers;
using TraineeManagement.Api.Exceptions;

namespace TraineeManagement.Api.Services;

public class TaskAssignmentService : ITaskAssignmentService
{
    private readonly AppDbContext _context;
    public TaskAssignmentService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<TaskAssignmentResponse>> GetAll()
    {
        IQueryable<TaskAssignment> query = _context.TaskAssignment;
        List<TaskAssignmentResponse> taskAssignments = await query.Select(t => new TaskAssignmentResponse(t)).ToListAsync();

        return taskAssignments;
    }
    public async Task<TaskAssignmentResponse?> GetById(int id)
    {
        TaskAssignment? taskAssignment = await _context.TaskAssignment.FindAsync(id);
        if (taskAssignment == null) return null;
        return new TaskAssignmentResponse(taskAssignment);
    }

    public async Task<TaskAssignmentResponse> AddNew(CreateTaskAssignmentRequest request)
    {
        bool TraineeExists = await _context.Trainees.AnyAsync(t => t.Id == request.TraineeId);
        if (!TraineeExists)throw new NotFoundException($"Trainee with TraineeId: {request.TraineeId} does not exists");
        bool MentorExists = await _context.Trainees.AnyAsync(t => t.Id == request.MentorId);
        if (!MentorExists) throw new NotFoundException($"Mentor with MentorId: {request.MentorId} does not exists");
        bool LearningTaskExists = await _context.Trainees.AnyAsync(t => t.Id == request.LearningTaskId);
        if (!LearningTaskExists) throw new NotFoundException($"Learning task with LearningTaskId: {request.LearningTaskId} does not exists");

        if (request.AssignedDate < request.DueDate) throw new NotFoundException("DueDate should not be before AssignedDate");
        TaskAssignment taskAssignment = new TaskAssignment(request);

        await _context.TaskAssignment.AddAsync(taskAssignment);
        await _context.SaveChangesAsync();

        TaskAssignmentResponse response = new TaskAssignmentResponse(taskAssignment);
        return response;
    }
    public async Task<TaskAssignmentResponse?> Update(int id, UpdateTaskAssignmentRequest request)
    {
        TaskAssignment? taskAssignment = await _context.TaskAssignment.FindAsync(id);
        if (taskAssignment == null) return null;
        taskAssignment.Status = request.Status;
        await _context.SaveChangesAsync();
        return await GetById(id);
    }
}