using asToolkit.Shipping.Models.Common;

namespace asToolkit.Shipping.Models.Gls;

/// <summary>
/// GLS-specific knobs from ShippingProvider.AdditionalConfigJson.
/// Credentials on the provider entity: Username/Password = GLS Web API user.
/// </summary>
public sealed class GlsCarrierConfig
{
    /// <summary>GLS contact id (ShipperId), e.g. "276a...". Required.</summary>
    public string ContactId { get; set; } = string.Empty;

    /// <summary>GLS product, defaults to the standard parcel.</summary>
    public string Product { get; set; } = "PARCEL";

    public CarrierSenderAddress Sender { get; set; } = new();
}
