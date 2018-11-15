using System.Collections.Specialized;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.ProductRatings
{
    public class ProductRatingSearchCriteria : PagedSearchCriteria
    {
        private static int _defaultPageSize = 20;

        public static int DefaultPageSize
        {
            get { return _defaultPageSize; }
            set { _defaultPageSize = value; }
        }

        public ProductRatingSearchCriteria()
            : base(new NameValueCollection(), _defaultPageSize)
        {
        }
        public ProductRatingSearchCriteria(NameValueCollection queryString)
            : base(queryString, DefaultPageSize)
        {
        }

        public string[] ProductIds { get; set; }
        public bool? IsActive { get; set; }
        public string Sort { get; set; }
    }
}
