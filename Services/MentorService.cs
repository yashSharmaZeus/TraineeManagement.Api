using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Helpers;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public class MentorService : IMentorService
{
    private readonly AppDbContext _context;

    public MentorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<MentorResponse>> GetAll(string? search, int pageNumber = 1, int pageSize = 10, string? status = null)
    {
        IQueryable<Mentor> query = _context.Mentors;
        if (!string.IsNullOrWhiteSpace(search))
        {
            string term = search.ToLower();
            query = query.Where(t =>
                t.FirstName.ToLower().Contains(term) ||
                t.LastName.ToLower().Contains(term) ||
                t.Email.ToLower().Contains(term) ||
                t.Expertise.ToLower().Contains(term)
            );
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            string term = status.ToLower();
            query = query.Where(t => t.Status.ToLower() == term);
        }

        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        int TotalCount = await query.CountAsync();

        List<MentorResponse> mentors = await query.Select(t => new MentorResponse(t)).ToListAsync();

        return new PagedResponse<MentorResponse>(mentors, TotalCount, pageNumber, pageSize);
    }

    public async Task<MentorResponse?> GetById(int id)
    {
        Mentor? mentor = await _context.Mentors.FindAsync(id);
        if (mentor == null) return null;
        return new MentorResponse(mentor);
    }

    public async Task<MentorResponse> AddNew(CreateMentorRequest request)
    {
        Mentor mentor = new Mentor(request);
        await _context.Mentors.AddAsync(mentor);
        await _context.SaveChangesAsync();
        return new MentorResponse(mentor);
    }

    public async Task<MentorResponse?> UpdateMentor(int id, UpdateMentorRequest request)
    {
        Mentor? mentor = await _context.Mentors.FindAsync(id);
        if (mentor == null) return null;
        mentor.FirstName = request.FirstName;
        mentor.LastName = request.LastName;
        mentor.Email = request.Email;
        mentor.Expertise = request.Expertise;
        mentor.Status = request.Status;
        mentor.UpdatedDate = DateHelper.Now();

        await _context.SaveChangesAsync();

        return await GetById(id);
    }
    public async Task<bool> DeleteMentor(int id)
    {
        Mentor? mentor = await _context.Mentors.FindAsync(id);

        if (mentor == null) return false;

        _context.Mentors.Remove(mentor);
        await _context.SaveChangesAsync();

        return true;
    }
}