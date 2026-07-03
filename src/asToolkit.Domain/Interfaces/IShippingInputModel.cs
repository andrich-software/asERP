namespace asToolkit.Domain.Interfaces;

public interface IShippingInputModel
{
    Guid SalesId { get; }
    Guid ShippingProviderRateId { get; }
    string? TrackingNumber { get; }
    decimal? ShippingCost { get; }
    double TaxRate { get; }
    decimal? WeightKg { get; }
    decimal? LengthCm { get; }
    decimal? WidthCm { get; }
    decimal? HeightCm { get; }
    List<Guid> SalesItemIds { get; }
    bool RequestLabel { get; }
}
