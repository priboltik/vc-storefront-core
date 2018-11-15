using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.Extensions.Primitives;
using VirtoCommerce.Storefront.Model.Common.Caching;

namespace VirtoCommerce.Storefront.Domain.ProductRating
{
    public class ProductRatingCacheRegion : CancellableCacheRegion<ProductRatingCacheRegion>
    {
        private static readonly ConcurrentDictionary<string, CancellationTokenSource> _customerProductRatingRegionTokenLookup =
            new ConcurrentDictionary<string, CancellationTokenSource>();

        public static IChangeToken CreateCustomerProductRatingChangeToken(string customerId)
        {
            if (customerId == null)
            {
                throw new ArgumentNullException(nameof(customerId));
            }
            var cancellationTokenSource = _customerProductRatingRegionTokenLookup.GetOrAdd(customerId, new CancellationTokenSource());
            return new CompositeChangeToken(new[]
            {
                CreateChangeToken(), new CancellationChangeToken(cancellationTokenSource.Token)
            });
        }

        public static void ExpireCustomerProductRating(string customerId)
        {
            if (!string.IsNullOrEmpty(customerId) && _customerProductRatingRegionTokenLookup.TryRemove(customerId, out var token))
            {
                token.Cancel();
            }
        }
    }
}
