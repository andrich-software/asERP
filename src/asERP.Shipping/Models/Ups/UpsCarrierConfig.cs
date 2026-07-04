using asERP.Shipping.Models.Common;

namespace asERP.Shipping.Models.Ups;

/// <summary>
/// UPS-specific knobs from ShippingProvider.AdditionalConfigJson.
/// Credentials on the provider entity: ApiKey/ApiSecret = OAuth client id/secret,
/// AccountNumber = UPS shipper number.
/// </summary>
public sealed class UpsCarrierConfig
{
    /// <summary>UPS service code, e.g. "11" (UPS Standard) or "03" (UPS Ground).</summary>
    public string ServiceCode { get; set; } = "11";

    public CarrierSenderAddress Sender { get; set; } = new();
}
