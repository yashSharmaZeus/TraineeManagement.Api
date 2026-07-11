using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace TraineeManagement.Api.Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IDistributedCache cache, ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<T?> GetDataAsync<T>(string Key)
    {
        try
        {

            string? cachedData = await _cache.GetStringAsync(Key);

            if (string.IsNullOrEmpty(cachedData))
            {
                _logger.LogInformation("cache miss {}", Key);
                return default;
            }

            _logger.LogInformation("cache hit {}", Key);
            return JsonSerializer.Deserialize<T>(cachedData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Redis error during GET for key {key}. Falling back to source.", Key);
            return default;
        }
    }

    public async Task SetDataAsync<T>(string Key, T data)
    {
        try
        {

            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            string JsonData = JsonSerializer.Serialize(data);
            await _cache.SetStringAsync(Key, JsonData, options);

            _logger.LogInformation("cache set {}", Key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Redis error during SET for key {key}.", Key);
        }
    }

    public async Task DeleteDataAsync(string Key)
    {
        try
        {

            await _cache.RemoveAsync(Key);
            _logger.LogInformation("cache deleted {}", Key);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Redis error during DELETE for key {key}.", Key);
        }
    }

    public async Task<bool> KeyExistsAsync(string Key)
    {
        try
        {
            return await _cache.GetAsync(Key) != null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Redis error during EXIST check for key {key}.", Key);
            return default;
        }
    }
}