using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.Shipping;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>
/// Pure helpers of the batch-shipping run (no UI, no I/O — unit-testable). A batch line
/// always ships ALL open items with their full quantities; deviating orders are meant to be
/// deselected and shipped via the regular create-shipment dialog.
/// </summary>
public static class BatchShipmentLogic
{
    /// <summary>Builds the create-shipment input for one order of the batch run: all open
    /// lines with full quantities, weight prefilled from the product weights.</summary>
    public static ShippingInputDto BuildInput(
        Guid salesId,
        Guid rateId,
        IReadOnlyList<ShippableSalesItemDto> openItems,
        bool requestLabel)
    {
        var weight = openItems.Sum(i => i.ProductWeight * (decimal)i.OpenQuantity);

        return new ShippingInputDto
        {
            SalesId = salesId,
            ShippingProviderRateId = rateId,
            TaxRate = openItems.Count > 0 ? openItems.Max(i => i.TaxRate) : 0,
            WeightKg = weight > 0 ? weight : null,
            RequestLabel = requestLabel,
            Items = openItems
                .Select(i => new ShippingItemInputDto { SalesItemId = i.SalesItemId, Quantity = i.OpenQuantity })
                .ToList(),
        };
    }
}
