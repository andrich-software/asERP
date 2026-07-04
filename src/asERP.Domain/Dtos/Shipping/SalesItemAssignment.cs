namespace asERP.Domain.Dtos.Shipping;

/// <summary>Assignment of an order line to a parcel; null quantity means the whole line.</summary>
public record SalesItemAssignment(Guid SalesItemId, double? Quantity)
{
    /// <summary>Shared tolerance for double quantity comparisons — a requested quantity within
    /// this distance of the line quantity counts as "the whole line" (no split).</summary>
    public const double QuantityTolerance = 0.0001;
}
