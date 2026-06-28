using asToolkit.Application.Specifications.Base;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Specifications
{
    /// <summary>
    /// Specification for filtering product attributes
    /// </summary>
    public class ProductAttributeFilterSpecification : FilterSpecification<ProductAttribute>
    {
        public ProductAttributeFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = a => a.Name.ToLower().Contains(searchString.ToLower());
            }
            else
            {
                Criteria = a => true;
            }
        }

        public ProductAttributeFilterSpecification(Guid id)
        {
            Criteria = a => a.Id == id;
        }
    }
}
