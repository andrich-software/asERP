namespace asToolkit.Client.Features.Shippings.Models;

/// <summary>Pure helpers for the create-shipment dialog defaults — unit-tested.</summary>
public static class ShipmentDraftLogic
{
    /// <summary>An item is pre-checked when the on-hand stock covers the full open quantity.</summary>
    public static bool IsInStock(double stockAvailable, double openQuantity) =>
        stockAvailable >= openQuantity;

    /// <summary>Parcel weight prefill: sum of unit weight × quantity over the selected rows.</summary>
    public static decimal CalculateWeight(IEnumerable<(bool Selected, double Quantity, decimal UnitWeightKg)> rows) =>
        rows.Where(r => r.Selected).Sum(r => r.UnitWeightKg * (decimal)r.Quantity);

    /// <summary>Rate preselect: the remembered rate if still offered, otherwise the first entry
    /// (the API returns rates sorted by price, so "first" means "cheapest").</summary>
    public static Guid? SelectDefaultRate(IReadOnlyList<Guid> rateIdsSortedByPrice, Guid? lastUsedRateId)
    {
        if (rateIdsSortedByPrice.Count == 0)
        {
            return null;
        }

        if (lastUsedRateId is Guid last && rateIdsSortedByPrice.Contains(last))
        {
            return last;
        }

        return rateIdsSortedByPrice[0];
    }
}
