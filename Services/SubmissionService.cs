using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Api.Exceptions;
using System.Security.Cryptography;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Services;

public class SubmissionService : ISubmissionService
{
    private readonly AppDbContext _context;
    private readonly ICacheService _cache;
    private readonly ILogger<SubmissionService> _logger;
    private readonly IFileStorageService _fileStorageService;
    public SubmissionService(AppDbContext context, ILogger<SubmissionService> logger, IFileStorageService fileStorageService, ICacheService cache)
    {
        _context = context;
        _logger = logger;
        _fileStorageService = fileStorageService;
        _cache = cache;
    }

    public async Task<List<SubmissionResponse>> GetAll()
    {
        IQueryable<Submission> query = _context.Submission;
        List<SubmissionResponse> submissions = await query.Select(t => new SubmissionResponse(t)).ToListAsync();

        return submissions;
    }
    public async Task<SubmissionResponse> GetById(int id)
    {
        string CacheKey = $"submission-summary:{id}";
        Submission? submissionCache = await _cache.GetDataAsync<Submission>(CacheKey);
        if (submissionCache != null)
        {
            return new SubmissionResponse(submissionCache);
        }

        Submission? submission = await _context.Submission.FindAsync(id);
        if (submission == null)
        {
            _logger.LogInformation("submission with ID {id} not found", id);
            throw new NotFoundException($"submission with ID {id} not found");
        }

        await _cache.SetDataAsync<Submission>(CacheKey, submission);
        return new SubmissionResponse(submission);
    }

    public async Task<SubmissionResponse> AddNew(CreateSubmissionRequest request)
    {
        bool taskAssignmentExists = await _context.TaskAssignment.AnyAsync(t => t.Id == request.TaskAssignmentId);
        if (!taskAssignmentExists)
        {
            _logger.LogInformation("Task assignment with Task assignment Id: {Id} does not exists", request.TaskAssignmentId);
            throw new NotFoundException($"Task assignment with Task assignment Id: {request.TaskAssignmentId} does not exists");
        }
        Submission taskAssignment = new Submission(request);

        await _context.Submission.AddAsync(taskAssignment);
        await _context.SaveChangesAsync();
        SubmissionResponse response = new SubmissionResponse(taskAssignment);
        return response;
    }

    public async Task<SubmissionFileResponse> UploadFile(int userId, int SubmissionId, SubmissionFileRequest request)
    {
        if (request.formFile == null)
        {
            _logger.LogInformation("empty File attempt");
            throw new BadRequestException("Cant upload empty file");
        }

        string fileName = request.formFile.FileName;
        if (!FileExtensionHelper.isValidFile(fileName))
        {
            throw new UnsupportedMediaType($"cant upload file with extension: {Path.GetExtension(fileName)}, Allowed extensions: .pdf, .zip, .png, .jpg, .jpeg");
        }

        if (request.formFile.Length > 20 * 1024 * 1024)
        {
            throw new PayLoadTooLarge("Max file size 20MB allowed");
        }

        bool SubmissionIdExists = await _context.Submission.AnyAsync(t => t.Id == SubmissionId);

        if (!SubmissionIdExists)
        {
            _logger.LogInformation("submission with Id: {id} not found", SubmissionId);
            throw new NotFoundException($"submission with submission Id: {SubmissionId} does not exists");
        }

        Stream stream = request.formFile.OpenReadStream();

        string uniqueFileName = await _fileStorageService.SaveAsync(stream, request.formFile.FileName);
        string checksum = CheckSumHelper.GetFileChecksum(stream);

        SubmissionFileMetaData submissionFileMetaData = new SubmissionFileMetaData(SubmissionId, fileName, uniqueFileName, request.formFile.ContentType, request.formFile.Length, checksum, userId);

        await _context.SubmissionFileMetaData.AddAsync(submissionFileMetaData);

        _context.SaveChanges();

        string username = await _context.User.Where(t => t.Id == userId).Select(u => u.Username).FirstOrDefaultAsync() ?? "";

        return new SubmissionFileResponse(submissionFileMetaData, username);
    }

    public async Task<FileStream> download(int id)
    {
        SubmissionFileMetaData? submissionFileMetaData = await _context.SubmissionFileMetaData.FindAsync(id);
        if (submissionFileMetaData == null)
        {
            throw new NotFoundException($"submission file with id:{id} not found");
        }
        FileStream stream = await _fileStorageService.OpenReadAsync(submissionFileMetaData.GeneratedStorageName);
        return stream;
    }

    public async Task<bool> delete(int id)
    {
        SubmissionFileMetaData? submissionFileMetaData = await _context.SubmissionFileMetaData.FindAsync(id);
        if (submissionFileMetaData == null)
        {
            throw new NotFoundException($"submission file with id:{id} not found");
        }
        return await _fileStorageService.DeleteAsync(submissionFileMetaData.GeneratedStorageName);
    }
}