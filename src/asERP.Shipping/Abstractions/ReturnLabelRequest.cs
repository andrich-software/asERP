namespace asERP.Shipping.Abstractions;

/// <summary>
/// Carrier-agnostic return-label request. The parcel travels FROM the customer BACK to the
/// merchant: the customer (order delivery address) is the sender printed on the label; the
/// return destination comes from each carrier's return configuration
/// (AdditionalConfigJson / return portal), not from here.
/// </summary>
public sealed record ReturnLabelRequest
{
    public required Guid ReturnShipmentId { get; init; }

    /// <summary>Customer reference printed on the label — the tenant-scoped order number.</summary>
    public required string Reference { get; init; }

    public required string CustomerName { get; init; }
    public string? CustomerCompany { get; init; }
    public string? CustomerPhone { get; init; }
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string Zip { get; init; }

    /// <summary>ISO 3166-1 alpha-2 country code of the customer address (e.g. "DE").</summary>
    public required string CountryIsoCode { get; init; }

    public decimal WeightKg { get; init; }
}
