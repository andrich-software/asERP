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

    /// <summary>Internal note shown in the management UI, e.g. contract details or usage hints.</summary>
    public string? Description { get; set; }

    /// <summary>Inactive options stay on historical shipments but are no longer offered for new ones.</summary>
    public bool IsActive { get; set; } = true;

    /// <summary>Display position in the shipment-creation picker (ascending, ties broken by price).</summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// Carrier product/service code booked by this option (DHL "V01PAK"/"V62WP", DPD "Classic",
    /// GLS "PARCEL", UPS service code "11"). Null falls back to the provider's default from
    /// <see cref="ShippingProvider.AdditionalConfigJson"/>.
    /// </summary>
    public string? CarrierProduct { get; set; }

    /// <summary>
    /// DHL only: billing procedure matching <see cref="CarrierProduct"/> (e.g. "01" for Paket,
    /// "62" for Warenpost) — DHL couples product and procedure in the billing number.
    /// </summary>
    public string? CarrierProcedure { get; set; }

    /// <summary>DHL only: participation number matching <see cref="CarrierProduct"/>.</summary>
    public string? CarrierParticipation { get; set; }

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
