using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Helpers;
using TraineeManagement.Api.Exceptions;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.Services;

public class LearningTaskService : ILearningTaskService
{
    private readonly AppDbContext _context;
    private readonly ILogger<LearningTaskService> _logger;

    public LearningTaskService(AppDbContext context, ILogger<LearningTaskService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedResponse<LearningTaskResponse>> GetAll(string? search, int pageNumber = 1, int pageSize = 10, string? status = null)
    {

        IQueryable<LearningTask> query = _context.LearningTask;
        if (!string.IsNullOrWhiteSpace(search))
        {
            string term = search.ToLower();
            query = query.Where(t =>
                t.Title.ToLower().Contains(term) ||
                t.Description.ToLower().Contains(term) ||
                t.ExpectedTechStack.ToLower().Contains(term)
            );
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            string term = status.ToLower();
            query = query.Where(t => t.Status.ToString() == term);
        }

        int TotalCount = await query.CountAsync();
        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        List<LearningTaskResponse> mentors = await query.Select(t => new LearningTaskResponse(t)).ToListAsync();

        return new PagedResponse<LearningTaskResponse>(mentors, TotalCount, pageNumber, pageSize);
    }

    public async Task<LearningTaskResponse> GetById(int id)
    {
        LearningTask? task = await _context.LearningTask.FindAsync(id);
        if (task == null)        
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            throw new NotFoundException($"learningTask with Id: {id} not found");
        }
        return new LearningTaskResponse(task);
    }
    public async Task<LearningTaskResponse> AddNew(CreateLearningTaskRequest request)
    {   
        if ( request.DueDate < DateHelper.Now())
        {   
            _logger.LogError("DueDate should be greater than current date ,Learning Task Title: {}:",request.Title);
            throw new BadRequestException(StringConstant.DUE_DATE_EXCEPTION);
        }
        LearningTask task = new LearningTask(request);
        await _context.LearningTask.AddAsync(task);
        await _context.SaveChangesAsync();
        return new LearningTaskResponse(task);
    }
    public async Task<LearningTaskResponse> UpdateTask(int id, UpdateLearningTaskRequest request)
    {   
        
        if ( request.DueDate < DateHelper.Now())
        {   
            _logger.LogError("DueDate should be greater than current date ,Learning Task Title: {}:",request.Title);
            throw new BadRequestException(StringConstant.DUE_DATE_EXCEPTION);
        }
        LearningTask? task = await _context.LearningTask.FindAsync(id);
        if (task == null)        
        {
            _logger.LogInformation("Task with ID {id} not found", id);
            throw new NotFoundException($"learningTask with Id: {id} not found");
        }
        task.Title = request.Title;
        task.Description = request.Description;
        task.ExpectedTechStack = request.ExpectedTechStack;
        task.DueDate = request.DueDate;
        task.Status = request.Status;
        task.UpdatedDate = DateHelper.Now();

        await _context.SaveChangesAsync();

        return await GetById(id);
    }
    public async Task<bool> DeleteTask(int id)
    {
        LearningTask? task = await _context.LearningTask.FindAsync(id);

        if (task == null) return false;

        _context.LearningTask.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }

}