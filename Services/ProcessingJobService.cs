using TraineeManagement.Api.Data;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Exceptions;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public class ProcessingJobService: IProcessingJobService
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProcessingJobService> _logger;
    public ProcessingJobService(AppDbContext context,ILogger<ProcessingJobService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<ProcessingJobResponse> GetById(int id)
    {
        ProcessingJob? processingJob = await _context.ProcessingJob.FindAsync(id);
        if (processingJob == null)
        {
            _logger.LogInformation("processing Job with ID {id} not found", id);
            throw new NotFoundException($"processing Job with ID {id} not found");
        }

        return new ProcessingJobResponse(processingJob);
    }
}