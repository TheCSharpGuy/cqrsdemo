namespace CQRSDemo.Caching
{
    public interface ICacheable
    {
        string CacheKey { get; }
    }
}
