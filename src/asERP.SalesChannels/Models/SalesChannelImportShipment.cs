namespace asERP.SalesChannels.Models;

/// <summary>
/// One parcel a shop recorded for an order. Channel-agnostic shape produced by the connectors and
/// consumed by <c>IShipmentImportRepository</c>.
/// <para>
/// Deliberately thin: shops rarely expose more than the number and the carrier behind it. Anything
/// the shop does not report (weight, dimensions, label) stays unset rather than being invented — an
/// imported shipment documents what the shop did, it is not a locally bookable label.
/// </para>
/// </summary>
public class SalesChannelImportShipment
{
    /// <summary>Channel-side order identifier; matched against <c>Sales.RemoteSalesId</c>.</summary>
    public string RemoteSalesId { get; set; } = string.Empty;

    /// <summary>Carrier tracking number exactly as the shop stored it.</summary>
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Carrier identifier as reported by the shop, resolved to a local shipping provider through the
    /// channel's carrier mappings. Empty when the shop reports no carrier at all.
    /// </summary>
    public string RemoteCarrierCode { get; set; } = string.Empty;

    /// <summary>UTC time the shop recorded the shipment, when known.</summary>
    public DateTime? ShippedAt { get; set; }
}
