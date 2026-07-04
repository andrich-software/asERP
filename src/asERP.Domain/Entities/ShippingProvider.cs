using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

public class ShippingProvider : BaseEntity, IBaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ShippingProviderType Type { get; set; }

    /// <summary>Kill-switch: disabled providers accept no new shipments and are skipped by the tracking poller.</summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>Route API calls to the carrier's sandbox/test environment instead of production.</summary>
    public bool UseSandbox { get; set; }

    public string Username { get; set; } = string.Empty;

    /// <summary>Encrypted at rest via <c>EncryptedStringConverter</c>.</summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>Carrier API key (encrypted at rest). E.g. the DHL <c>dhl-api-key</c> or UPS client id.</summary>
    public string? ApiKey { get; set; }

    /// <summary>Carrier API secret (encrypted at rest). E.g. the UPS client secret.</summary>
    public string? ApiSecret { get; set; }

    /// <summary>Carrier account/customer number (DHL EKP, UPS shipper number, ...). Not secret.</summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Free-form connector configuration (sender address, DHL participation/procedure, GLS contact id,
    /// DPD depot, UPS service code, ...). Schema is owned by the connector.
    /// </summary>
    public string? AdditionalConfigJson { get; set; }

    /// <summary>Minimum seconds between tracking polls per shipment of this provider. Defaults to 1h.</summary>
    public int TrackingPollIntervalSeconds { get; set; } = 3600;

    /// <summary>UTC time the tracking poller last started a pass for this provider.</summary>
    public DateTime? LastTrackingPollStartedAt { get; set; }

    public virtual ICollection<ShippingProviderRate>? ShippingRates { get; set; }
}
