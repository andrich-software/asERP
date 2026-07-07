using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Feed;

public class FeedInputDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public FeedTemplate Template { get; set; }

    /// <summary>ISO 4217 currency code emitted for every product price.</summary>
    public string Currency { get; set; } = "EUR";

    /// <summary>Optional Shopware6/WooCommerce channel used to build product deep-links.</summary>
    public Guid? SalesChannelId { get; set; }

    public bool IsEnabled { get; set; } = true;

    /// <summary>idealo delivery time (e.g. "1-3 Tage").</summary>
    public string? DefaultDeliveryTime { get; set; }

    /// <summary>idealo delivery cost per offer.</summary>
    public decimal? DefaultShippingCost { get; set; }
}
