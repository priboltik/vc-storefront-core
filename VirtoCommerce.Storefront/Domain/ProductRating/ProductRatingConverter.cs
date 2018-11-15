using VirtoCommerce.Storefront.Model.ProductRatings;
using reviewDto = VirtoCommerce.Storefront.AutoRestClients.ProductsRating.WebModuleApi.Models;

namespace VirtoCommerce.Storefront.Domain.ProductRating
{
    public static partial class ProductRatingConverter
    {
        public static Model.ProductRatings.ProductRating ToProductRating(this reviewDto.ProductRating itemDto)
        {
            var result = new Model.ProductRatings.ProductRating
            {
                Id = itemDto.Id,
                AuthorNickname = itemDto.AuthorNickname,
                Rating = itemDto.Rating.Value,
                CreatedBy = itemDto.CreatedBy,
                CreatedDate = itemDto.CreatedDate,
                IsActive = itemDto.IsActive,
                ModifiedBy = itemDto.ModifiedBy,
                ModifiedDate = itemDto.ModifiedDate,
                ProductId = itemDto.ProductId
            };

            return result;
        }

        public static reviewDto.ProductRatingSearchCriteria ToSearchCriteriaDto(this ProductRatingSearchCriteria criteria)
        {
            var result = new reviewDto.ProductRatingSearchCriteria
            {
                IsActive = criteria.IsActive,
                ProductIds = criteria.ProductIds,

                Skip = criteria.Start,
                Take = criteria.PageSize,
                Sort = criteria.Sort
            };

            return result;
        }
    }
}
