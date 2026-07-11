using TraineeManagement.Api.Exceptions;
using TraineeManagement.Api.Data;

namespace TraineeManagement.Api.Services;

public class FileStorageService : IFileStorageService
{
    public readonly string _storageRoot;
    private readonly AppDbContext _context;
    public readonly ILogger<FileStorageService> _logger;

    public FileStorageService(IConfiguration configuration, ILogger<FileStorageService> logger, AppDbContext context)
    {
        _storageRoot = configuration["FileStorageSettings: StorageRoot"] ?? "Storage";
        Directory.CreateDirectory(_storageRoot);
        _logger = logger;
        _context = context;
    }

    public string getFullPath(string fileName)
    {
        return Path.Combine(_storageRoot, fileName);
    }


    public async Task<string> SaveAsync(Stream fileStream, string originalFileName)
    {
        if (fileStream == null)
        {
            _logger.LogInformation("empty File upload attempt");
            throw new BadRequestException("Cant upload empty file");
        }

        string extension = Path.GetExtension(originalFileName);
        string uniqueFileName = $"{Guid.NewGuid()}{extension}";

        string fullPhysicalPath = Path.Combine(_storageRoot, uniqueFileName);
        using var destinationStream = new FileStream(fullPhysicalPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await fileStream.CopyToAsync(destinationStream);

        return uniqueFileName;
    }

    public async Task<FileStream> OpenReadAsync(string fileName)
    {
        string fullPath = getFullPath(fileName);
        if (!File.Exists(fullPath))
        {
            _logger.LogInformation("Requested File does not exists: {}", fileName);
            throw new FileNotFoundException("Requested File does not exists");
        }
        FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);

        return stream;
    }

    public async Task<bool> ExistsAsync(string fileName)
    {
        string fullPath = getFullPath(fileName);
        return File.Exists(fullPath);
    }

    public async Task<bool> DeleteAsync(string fileName)
    {
        string fullPath = getFullPath(fileName);
        if (File.Exists(fullPath))
        {
            _logger.LogInformation("File deleted successfully: {}", fileName);
            File.Delete(fullPath);
            return true;
        }
        return false;
    }

}