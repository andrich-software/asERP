namespace asERP.Shipping.Abstractions;

/// <summary>
/// Carrier-agnostic label request. Built once by the carrier service from the shipment and its
/// order; connectors translate it into their API DTOs. The sender address comes from the
/// provider's AdditionalConfigJson, not from here.
/// </summary>
public sealed record ShipmentLabelRequest
{
    public required Guid ShippingId { get; init; }

    /// <summary>Customer reference printed on the label — the tenant-scoped order number.</summary>
    public required string Reference { get; init; }

    public required string RecipientName { get; init; }
    public string? RecipientCompany { get; init; }
    public string? RecipientPhone { get; init; }
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string Zip { get; init; }

    /// <summary>ISO 3166-1 alpha-2 destination country code (e.g. "DE").</summary>
    public required string CountryIsoCode { get; init; }

    public decimal WeightKg { get; init; }
    public decimal? LengthCm { get; init; }
    public decimal? WidthCm { get; init; }
    public decimal? HeightCm { get; init; }
}
