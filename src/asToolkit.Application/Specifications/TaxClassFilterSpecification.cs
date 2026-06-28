using asToolkit.Application.Specifications.Base;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Specifications
{
    /// <summary>
    /// Specification for filtering tax classes
    /// </summary>
    public class TaxClassFilterSpecification : FilterSpecification<TaxClass>
    {
        public TaxClassFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                Criteria = t => (t.TaxRate.ToString().Contains(searchString));
            }
            else
            {
                Criteria = p => true;
            }
        }

        public TaxClassFilterSpecification(Guid id)
        {
            Criteria = o => o.Id == id;
        }
    }
}
