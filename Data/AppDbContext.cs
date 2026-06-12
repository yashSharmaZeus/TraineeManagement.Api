using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Trainee> Trainees {get;set;}
    
    public DbSet<User> User {get;set;}
    
    public DbSet<Mentor> Mentors {get;set;}
    public DbSet<LearningTask> LearningTask {get;set;}
}