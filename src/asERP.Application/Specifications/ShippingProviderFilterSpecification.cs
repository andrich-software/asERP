using asERP.Application.Specifications.Base;
using asERP.Domain.Entities;

namespace asERP.Application.Specifications;

/// <summary>
/// Specification for filtering shipping providers
/// </summary>
public class ShippingProviderFilterSpecification : FilterSpecification<ShippingProvider>
{
    public ShippingProviderFilterSpecification(string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            var lowerSearchString = searchString.ToLower();
            Criteria = p => p.Name.ToLower().Contains(lowerSearchString);
        }
        else
        {
            Criteria = p => true;
        }
    }
}
