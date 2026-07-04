using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.Shipping;

public class ShippingInputDto : IShippingInputModel
{
    public Guid SalesId { get; set; }

    /// <summary>The chosen shipping option — the provider is derived from it.</summary>
    public Guid ShippingProviderRateId { get; set; }

    /// <summary>Manually entered tracking number; usually filled by the carrier connector instead.</summary>
    public string? TrackingNumber { get; set; }

    /// <summary>Defaults to the rate's price when null.</summary>
    public decimal? ShippingCost { get; set; }

    public double TaxRate { get; set; }

    public decimal? WeightKg { get; set; }
    public decimal? LengthCm { get; set; }
    public decimal? WidthCm { get; set; }
    public decimal? HeightCm { get; set; }

    /// <summary>Order lines packed into this parcel as whole lines. Optional.</summary>
    public List<Guid> SalesItemIds { get; set; } = new();

    /// <summary>Order lines packed with explicit quantities — a quantity below the line's
    /// open quantity splits the line into a shipped and a remaining part. Optional.</summary>
    public List<ShippingItemInputDto> Items { get; set; } = new();

    /// <summary>Request a carrier label immediately after creation.</summary>
    public bool RequestLabel { get; set; } = true;
}
