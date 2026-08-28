using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.SalesChannel;

public class SalesChannelDetailDto
{
    public Guid Id { get; set; }
    public SalesChannelType SalesChannelType { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    /// <summary>Free-form connector configuration (never contains secrets — see input DTO).</summary>
    public string? AdditionalConfigJson { get; set; }

    public bool ImportProducts { get; set; }
    public bool ExportProducts { get; set; }
    public bool ImportCustomers { get; set; }
    public bool ExportCustomers { get; set; }
    public bool ImportSaless { get; set; }
    public bool ExportSaless { get; set; }

    /// <summary>Receive stock pushes whenever the mirrored warehouse stock changes.</summary>
    public bool ExportStock { get; set; }

    /// <summary>Push local order cancellations back to this channel (opt-in, default off).</summary>
    public bool PushSalesCancellations { get; set; }

    /// <summary>This channel is the stock master — its levels are mirrored into the linked warehouse.</summary>
    public bool ImportStock { get; set; }

    /// <summary>Pull the channel's category tree (runs before product imports).</summary>
    public bool ImportCategories { get; set; }

    /// <summary>Push local category changes and product category assignments to the channel.</summary>
    public bool ExportCategories { get; set; }

    /// <summary>
    /// Direction of the shipment-tracking exchange: import the shop's tracking numbers, push local
    /// ones, or neither.
    /// </summary>
    public ShipmentTrackingMode ShipmentTrackingMode { get; set; } = ShipmentTrackingMode.None;

    /// <summary>Carrier translations configured for this channel.</summary>
    public List<SalesChannelCarrierMappingDto> CarrierMappings { get; set; } = new();

    /// <summary>True when an inbound webhook secret is configured (the secret itself is never exposed).</summary>
    public bool HasWebhookSecret { get; set; }

    /// <summary>
    /// True if the channel has a stored refresh token (OAuth flow has been completed).
    /// The token itself is never exposed in the DTO.
    /// </summary>
    public bool HasRefreshToken { get; set; }

    /// <summary>UTC expiry of the current access token; null if not connected or never used.</summary>
    public DateTime? TokenExpiresAt { get; set; }

    public List<WarehouseDetailDto> Warehouses { get; set; } = new();

    /// <summary>Host bindings of an asShop channel (empty for every other channel type).</summary>
    public List<ShopDomainListDto> ShopDomains { get; set; } = new();
}

