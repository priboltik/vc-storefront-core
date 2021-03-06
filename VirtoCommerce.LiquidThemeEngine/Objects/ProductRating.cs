using System;
using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    public class ProductRating : Drop
    {
        public string AuthorNickname { get; set; }
        public int Rating { get; set; }
        public bool? IsActive { get; set; }
        public string ProductId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
