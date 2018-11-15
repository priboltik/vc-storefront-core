using VirtoCommerce.LiquidThemeEngine.Objects;
using storefrontModel = VirtoCommerce.Storefront.Model.ProductRatings;


namespace VirtoCommerce.LiquidThemeEngine.Converters
{
    public static class ProductRatingConverter
    {
        public static ProductRating ToShopifyModel(this storefrontModel.ProductRating item)
        {
            return new ShopifyModelConverter().ToLiquidProductRating(item);
        }
    }

    public partial class ShopifyModelConverter
    {
        public virtual ProductRating ToLiquidProductRating(storefrontModel.ProductRating item)
        {
            return new ProductRating
            {
                AuthorNickname = item.AuthorNickname,
                Rating = item.Rating,
                CreatedDate = item.CreatedDate,
                IsActive = item.IsActive,
                ProductId = item.ProductId
            };
        }
    }
}
