using asERP.Application.Specifications.Base;
using asERP.Domain.Entities;

namespace asERP.Application.Specifications
{
    /// <summary>
    /// Specification for filtering products
    /// </summary>
    public class ProductFilterSpecification : FilterSpecification<Product>
    {
        public ProductFilterSpecification(string searchString, bool includeVariants = false)
        {
            Includes.Add(p => p.ProductStocks);
            // Includes.Add(p => p.ProductSalesChannels);

            if (!string.IsNullOrEmpty(searchString))
            {
                var lowerSearchString = searchString.ToLower();
                Criteria = p => (includeVariants || p.ProductType != Domain.Enums.ProductType.Variant)
                    && (p.Sku.ToLower().Contains(lowerSearchString) || p.Name.ToLower().Contains(lowerSearchString));
            }
            else
            {
                Criteria = p => includeVariants || p.ProductType != Domain.Enums.ProductType.Variant;
            }
        }

        public ProductFilterSpecification(Guid id)
        {
            Includes.Add(p => p.ProductStocks);
            // Includes.Add(p => p.ProductSalesChannels):
            Criteria = o => o.Id == id;
        }
    }
}