namespace Core.Application.Pipelines.Caching;

public interface ICachableRequest
{
    public string CacheKey { get; }

    public bool BypassCache { get; }

    public TimeSpan? SlidingExpiration { get; }
}
