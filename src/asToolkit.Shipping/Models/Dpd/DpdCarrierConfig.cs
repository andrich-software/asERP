using asToolkit.Shipping.Models.Common;

namespace asToolkit.Shipping.Models.Dpd;

/// <summary>
/// DPD-specific knobs from ShippingProvider.AdditionalConfigJson.
/// Credentials on the provider entity: Username = DPD Cloud user id, ApiKey = Cloud token.
/// [verify] Contract flavor — this connector targets the DPD Cloud Webservice (REST); classic
/// Web Connect (SOAP) tenants need a different integration.
/// </summary>
public sealed class DpdCarrierConfig
{
    /// <summary>DPD product/parcel type, e.g. "Classic".</summary>
    public string Product { get; set; } = "Classic";

    /// <summary>Label size for the PDF, e.g. "PDF_A6" or "PDF_A4".</summary>
    public string LabelSize { get; set; } = "PDF_A6";

    public CarrierSenderAddress Sender { get; set; } = new();
}
