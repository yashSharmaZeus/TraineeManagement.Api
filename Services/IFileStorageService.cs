using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(Stream fileStream, string originalFileName );
    Task<FileStream> OpenReadAsync(string fileName);
    Task<bool> ExistsAsync(string fileName);
    Task<bool> DeleteAsync(string fileName); 
}