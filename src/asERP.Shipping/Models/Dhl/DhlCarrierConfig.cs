using asERP.Shipping.Models.Common;

namespace asERP.Shipping.Models.Dhl;

/// <summary>
/// DHL-specific knobs from ShippingProvider.AdditionalConfigJson.
/// Credentials live on the provider entity: Username/Password = business-portal login,
/// ApiKey = the dhl-api-key, AccountNumber = EKP (10 digits).
/// </summary>
public sealed class DhlCarrierConfig
{
    /// <summary>Billing procedure, e.g. "01" for DHL Paket.</summary>
    public string Procedure { get; set; } = "01";

    /// <summary>Participation number of the billing number, e.g. "01".</summary>
    public string Participation { get; set; } = "01";

    /// <summary>Product code override. Defaults to V01PAK (national) / V53WPAK (international).</summary>
    public string? Product { get; set; }

    /// <summary>Separate key for the Unified Tracking API; falls back to the provider ApiKey.</summary>
    public string? TrackingApiKey { get; set; }

    /// <summary>
    /// Receiver id ("Retourenempfänger") from the DHL business portal — identifies the return
    /// destination per country. Required for return labels.
    /// </summary>
    public string? ReturnReceiverId { get; set; }

    /// <summary>Billing procedure for returns, e.g. "07" (DHL Retoure).</summary>
    public string ReturnProcedure { get; set; } = "07";

    public CarrierSenderAddress Sender { get; set; } = new();
}
