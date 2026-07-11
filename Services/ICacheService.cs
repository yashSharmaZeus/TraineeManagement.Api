namespace TraineeManagement.Api.Services;

public interface ICacheService
{
    Task<T?> GetDataAsync<T>(string Key);
    Task SetDataAsync<T>(string Key, T data);
    Task DeleteDataAsync(string Key);
    Task<bool> KeyExistsAsync(string Key);

}