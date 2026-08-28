namespace asERP.Domain.Dtos.SalesChannel;

/// <summary>
/// One carrier translation row submitted with the channel form. The full set replaces the stored
/// mappings on save — the client always sends the complete list.
/// </summary>
public class SalesChannelCarrierMappingInputDto
{
    /// <summary>Carrier identifier as reported by the shop (WooCommerce: the order's shipping method id).</summary>
    public string RemoteCarrierCode { get; set; } = string.Empty;

    public Guid ShippingProviderId { get; set; }
}

/// <summary>Carrier translation row as returned by the channel detail query.</summary>
public class SalesChannelCarrierMappingDto
{
    public Guid Id { get; set; }

    public string RemoteCarrierCode { get; set; } = string.Empty;

    public Guid ShippingProviderId { get; set; }

    /// <summary>Display name of the mapped provider, so the form can render the row without a second lookup.</summary>
    public string ShippingProviderName { get; set; } = string.Empty;
}
