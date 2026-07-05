using asERP.Shipping.Models.Common;

namespace asERP.Shipping.Models.Dpd;

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

    /// <summary>DPD return product/parcel type. [verify] exact ShipService value per contract.</summary>
    public string ReturnProduct { get; set; } = "Returns";

    public CarrierSenderAddress Sender { get; set; } = new();
}
