using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Helpers;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Trainee> Trainees { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<Mentor> Mentors { get; set; }
    public DbSet<LearningTask> LearningTask { get; set; }
    public DbSet<TraineeStatus> TraineeStatus { get; set; }
    public DbSet<MentorStatus> MentorStatus { get; set; }
    public DbSet<TaskAssignmentStatus> TaskAssignmentStatus { get; set; }
    public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    public DbSet<ReviewStatus> ReviewStatus { get; set; }
    public DbSet<LearningTaskStatus> LearningTaskStatus { get; set; }
    public DbSet<TaskAssignment> TaskAssignment { get; set; }
    public DbSet<Submission> Submission { get; set; }
    public DbSet<Review> Review { get; set; }
    public DbSet<SubmissionFileMetaData> SubmissionFileMetaData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TraineeStatus>().HasData(
            new TraineeStatus { Id = 1, StatusId = 0, Status = "Active" },
            new TraineeStatus { Id = 2, StatusId = 1, Status = "Inactive" },
            new TraineeStatus { Id = 3, StatusId = 2, Status = "Completed" }
        );
        modelBuilder.Entity<MentorStatus>().HasData(
            new MentorStatus { Id = 1, StatusId = 0, Status = "Active" },
            new MentorStatus { Id = 2, StatusId = 1, Status = "Inactive" }
        );
        modelBuilder.Entity<LearningTaskStatus>().HasData(
            new LearningTaskStatus { Id = 1, StatusId = 0, Status = "Draft" },
            new LearningTaskStatus { Id = 2, StatusId = 1, Status = "Published" },
            new LearningTaskStatus { Id = 3, StatusId = 2, Status = "Closed" }
        );
        modelBuilder.Entity<TaskAssignmentStatus>().HasData(
            new TaskAssignmentStatus { Id = 1, StatusId = 0, Status = "Assigned" },
            new TaskAssignmentStatus { Id = 2, StatusId = 1, Status = "InProgress" },
            new TaskAssignmentStatus { Id = 3, StatusId = 2, Status = "Submitted" },
            new TaskAssignmentStatus { Id = 4, StatusId = 3, Status = "Reviewed" },
            new TaskAssignmentStatus { Id = 5, StatusId = 4, Status = "Completed" }
        );
        modelBuilder.Entity<SubmissionStatus>().HasData(
            new SubmissionStatus { Id = 1, StatusId = 0, Status = "Submitted" },
            new SubmissionStatus { Id = 2, StatusId = 1, Status = "Resubmitted" }
        );
        modelBuilder.Entity<ReviewStatus>()
        .Property(e => e.Status)
        .HasColumnType("varchar")
        .HasMaxLength(25);
        modelBuilder.Entity<ReviewStatus>().HasData(
            new ReviewStatus { Id = 1, StatusId = 0, Status = "Accepted" },
            new ReviewStatus { Id = 2, StatusId = 1, Status = "ChangesRequired" },
            new ReviewStatus { Id = 3, StatusId = 2, Status = "Rejected" }
        );
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "Admin", Email = "Admin@gmail.com", PasswordHash = "AQAAAAIAAYagAAAAEKZbq3NQIBWQ2/R+xBuFq1yCCAZ2bfdBV/hwvTtkDT2nT/6EblN6/I/98TZCSNlVMQ==", Role = "Admin", CreatedDate = DateHelper.Now(), UpdateDate = DateHelper.Now() }
        );
    }
}