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
    public DbSet<TraineeStatus> TraineeStatus {get;set;}
    public DbSet<MentorStatus> MentorStatus {get;set;}
    public DbSet<LearningTaskStatus> LearningTaskStatus {get;set;}
    public DbSet<TaskAssignment> TaskAssignment {get;set;}
    public DbSet<Submission> Submission {get;set;}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TraineeStatus>().HasData(
            new TraineeStatus { Id = 1, StatusId = 0,Status= "Active" },
            new TraineeStatus { Id = 2, StatusId = 1,Status= "Inactive" },
            new TraineeStatus { Id = 3, StatusId = 2,Status= "Completed" }
        );
        modelBuilder.Entity<MentorStatus>().HasData(
            new MentorStatus { Id = 1, StatusId = 0,Status= "Active" },
            new MentorStatus { Id = 2, StatusId = 1,Status= "Inactive" }
        );
        modelBuilder.Entity<LearningTaskStatus>().HasData(
            new LearningTaskStatus { Id = 1, StatusId = 0,Status= "Draft" },
            new LearningTaskStatus { Id = 2, StatusId = 1,Status= "Published" },
            new LearningTaskStatus { Id = 3, StatusId = 2,Status= "Closed" }
        );
    }
}