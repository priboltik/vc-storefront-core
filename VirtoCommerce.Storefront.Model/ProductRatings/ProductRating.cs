using System;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.ProductRatings
{
    public partial class ProductRating : Entity
    {
        public string AuthorNickname { get; set; }
        public int Rating { get; set; }
        public bool? IsActive { get; set; }
        public string ProductId { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
