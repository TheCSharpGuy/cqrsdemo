using CQRSDemo.Caching;
using CQRSDemo.DTOs;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDemo.Behaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : ICacheable
            where TResponse : BaseResponse
    {
        private readonly IMemoryCache cache;
        private readonly ILogger<CachingBehaviour<TRequest, TResponse>> logger;
        public CachingBehaviour(IMemoryCache cache, ILogger<CachingBehaviour<TRequest, TResponse>> logger)
        {
            this.cache = cache;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            logger.LogInformation($"{requestName} is configured for caching.");

            // Check to see if the item is inside the cache
            if (cache.TryGetValue(request.CacheKey, out TResponse response))
            {
                logger.LogInformation($"Fetching from cached value for {requestName}.");
                return response;
            }

            // Item is not in the cache, execute request and add to cache
            logger.LogInformation($"{requestName} Cache Key: {request.CacheKey} is not in the cache, fetching request from data store.");
            response = await next();
            cache.Set(request.CacheKey, response);
            return response;
        }
    }
}
