using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PagedList.Core;
using VirtoCommerce.Storefront.AutoRestClients.ProductsRating.WebModuleApi;
using VirtoCommerce.Storefront.Extensions;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model.Caching;
using VirtoCommerce.Storefront.Model.Common.Caching;
using VirtoCommerce.Storefront.Model.ProductRatings;

namespace VirtoCommerce.Storefront.Domain.ProductRating
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IProductsRating _productRatingsApi;
        private readonly IStorefrontMemoryCache _memoryCache;
        private readonly IApiChangesWatcher _apiChangesWatcher;

        public ProductRatingService(IProductsRating productRatingsApi, IStorefrontMemoryCache memoryCache, IApiChangesWatcher apiChangesWatcher)
        {
            _productRatingsApi = productRatingsApi;
            _memoryCache = memoryCache;
            _apiChangesWatcher = apiChangesWatcher;
        }

        public IPagedList<Model.ProductRatings.ProductRating> SearchRatings(ProductRatingSearchCriteria criteria)
        {
            return SearchRatingsAsync(criteria).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<Model.ProductRatings.ProductRating>> SearchRatingsAsync(ProductRatingSearchCriteria criteria)
        {
            var cacheKey = CacheKey.With(GetType(), nameof(SearchRatingsAsync), criteria.GetCacheKey());
            return await _memoryCache.GetOrCreateExclusiveAsync(cacheKey, async (cacheEntry) =>
            {
                cacheEntry.AddExpirationToken(ProductRatingCacheRegion.CreateChangeToken());
                cacheEntry.AddExpirationToken(_apiChangesWatcher.CreateChangeToken());

                var result = await _productRatingsApi.SearchProductsRatingAsync(criteria.ToSearchCriteriaDto());
                return new StaticPagedList<Model.ProductRatings.ProductRating>(result.Results.Select(x => x.ToProductRating()),
                    criteria.PageNumber, criteria.PageSize, result.TotalCount.Value);
            });
        }
    }
}
