using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace TraineeManagement.Api.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IDistributedCache cache,ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetDataAsync<T>(string Key)
    {
        string? cachedData = await _cache.GetStringAsync(Key);

        if (string.IsNullOrEmpty(cachedData))
        {
            _logger.LogInformation("cache miss {}",Key);
            return default;
        }

        _logger.LogInformation("cache hit {}",Key);
        return JsonSerializer.Deserialize<T>(cachedData);
    }

    public async Task SetDataAsync<T>(string Key,T data)
    {
        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };

        string JsonData = JsonSerializer.Serialize(data);
        _logger.LogInformation("cache set {}",Key);

        await _cache.SetStringAsync(Key,JsonData,options);
    }

    public async Task DeleteDataAsync(string Key)
    {
        _logger.LogInformation("cache deleted {}",Key);
        await _cache.RemoveAsync(Key);
    }

    public async Task<bool> KeyExistsAsync(string Key)
    {
        return await _cache.GetAsync(Key) != null;
    }
}