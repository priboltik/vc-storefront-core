using System.Threading.Tasks;
using PagedList.Core;

namespace VirtoCommerce.Storefront.Model.ProductRatings
{
    public interface IProductRatingService
    {
        IPagedList<ProductRating> SearchRatings(ProductRatingSearchCriteria criteria);
        Task<IPagedList<ProductRating>> SearchRatingsAsync(ProductRatingSearchCriteria criteria);
    }
}
