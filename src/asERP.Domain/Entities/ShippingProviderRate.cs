using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// A bookable shipping option of a provider: size/weight limits, price and the set of
/// destination countries it may ship to.
/// </summary>
public class ShippingProviderRate : BaseEntity, IBaseEntity
{
    public Guid ShippingProviderId { get; set; }

    // Not auto-initialized — see the phantom-entity note on ProductSalesChannel.
    public ShippingProvider ShippingProvider { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    /// <summary>Maximum parcel length in cm.</summary>
    public decimal MaxLength { get; set; }

    /// <summary>Maximum parcel width in cm.</summary>
    public decimal MaxWidth { get; set; }

    /// <summary>Maximum parcel height in cm.</summary>
    public decimal MaxHeight { get; set; }

    /// <summary>Maximum parcel weight in kg.</summary>
    public decimal MaxWeight { get; set; }

    /// <summary>Shipping cost charged for this option.</summary>
    public decimal Price { get; set; }

    public ICollection<ShippingProviderRateCountry> AllowedCountries { get; set; } = new List<ShippingProviderRateCountry>();
}
