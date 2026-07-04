using asToolkit.Application.Specifications.Base;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Specifications;

/// <summary>
/// Search filter for the tenant-wide shipment list: tracking number, recipient
/// (company or first/last name) and order number.
/// </summary>
public class ShippingFilterSpecification : FilterSpecification<Shipping>
{
    public ShippingFilterSpecification(string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            var lowerSearchString = searchString.ToLower();
            Criteria = s => s.TrackingNumber.ToLower().Contains(lowerSearchString)
                || s.Sales.SalesId.ToString().Contains(searchString)
                || s.Sales.DeliveryAddressCompanyName.ToLower().Contains(lowerSearchString)
                || (s.Sales.DeliveryAddressFirstName + " " + s.Sales.DeliveryAddressLastName)
                    .ToLower().Contains(lowerSearchString);
        }
        else
        {
            Criteria = s => true;
        }
    }
}
