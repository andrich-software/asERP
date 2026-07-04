using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Dtos.Shipping;

/// <summary>
/// A shipping option applicable to a specific sales order (enabled provider, destination
/// country allowed). Used to populate the option picker of the create-shipment dialog.
/// </summary>
public class ApplicableShippingRateDto
{
    public Guid RateId { get; set; }
    public string RateName { get; set; } = string.Empty;
    public Guid ProviderId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public ShippingProviderType ProviderType { get; set; }
    public decimal Price { get; set; }

    /// <summary>Maximum parcel weight in kg.</summary>
    public decimal MaxWeight { get; set; }

    /// <summary>Maximum parcel length in cm.</summary>
    public decimal MaxLength { get; set; }

    /// <summary>Maximum parcel width in cm.</summary>
    public decimal MaxWidth { get; set; }

    /// <summary>Maximum parcel height in cm.</summary>
    public decimal MaxHeight { get; set; }
}
