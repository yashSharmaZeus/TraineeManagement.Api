using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Services;

public class TraineeService : ITraineeService
{
    private readonly AppDbContext _context;
    public TraineeService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<PagedResponse<TraineeResponse>> GetAll(string? search = null,int pageNumber = 1,int pageSize = 10, string? status = null)
    {
        IQueryable<Trainee> query = _context.Trainees; 

        if (!string.IsNullOrWhiteSpace(search))
        {
            string term = search.ToLower();
            query = query.Where(t =>
                t.FirstName.ToLower().Contains(term) ||
                t.LastName.ToLower().Contains(term) ||
                t.Email.ToLower().Contains(term) ||
                t.TechStack.ToLower().Contains(term)
            );  
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            string term = status.ToLower();
            query = query.Where(t => t.Status.ToLower() == term);
        }

        query =  query.Skip((pageNumber -1)*pageSize).Take(pageSize);
        int TotalCount = await query.CountAsync();
        List<TraineeResponse> trainees = await query.Select(t => new TraineeResponse(t)).ToListAsync();
        return new PagedResponse<TraineeResponse>(trainees, TotalCount ,pageNumber , pageSize);
    }

    public async Task<TraineeResponse?> GetById(int id)
    {
        Trainee? trainee = await _context.Trainees.FindAsync(id);
        if (trainee == null) return null;
        return new TraineeResponse(trainee);
    }

    public async Task<TraineeResponse> AddNew(CreateTraineeRequest request)
    {
        Trainee trainee = new Trainee(request);
        await _context.Trainees.AddAsync(trainee);
        await _context.SaveChangesAsync();
        return new TraineeResponse(trainee);
    }

    public async Task<TraineeResponse?> UpdateTrainee(int id, UpdateTraineeRequest request)
    {
        Trainee? trainee = await _context.Trainees.FindAsync(id);
        if (trainee == null) return null;
        trainee.FirstName = request.FirstName;
        trainee.LastName = request.LastName;
        trainee.Email = request.Email;
        trainee.TechStack = request.TechStack;
        trainee.Status = request.Status;
        trainee.UpdatedDate = DateHelper.Now();
        await _context.SaveChangesAsync();
        
        return await GetById(id);
    }

    public async Task<bool> DeleteTrainee(int id)
    {
        Trainee? trainee = await _context.Trainees.FindAsync(id);
        
        if (trainee == null) return false;
        
        _context.Trainees.Remove(trainee);
        await _context.SaveChangesAsync();

        return true;
    }
}