using System.Text.Json;
using System.Text.Json.Serialization;
using asToolkit.Domain.Entities;

namespace asToolkit.SalesChannels.Models.eBay;

/// <summary>
/// Strongly-typed slice of <c>SalesChannel.AdditionalConfigJson</c> for eBay. Listing a product
/// (create + publish offer) needs the seller's business policies and inventory location — these
/// are per-channel constants configured once, while the category can additionally be overridden
/// per product via <c>ProductSalesChannel.MetadataJson</c>.
/// </summary>
public sealed class EbayChannelConfig
{
    /// <summary>Marketplace to publish offers on (e.g. "EBAY_DE"). Falls back to <see cref="SalesChannel.MarketplaceId"/>.</summary>
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; set; }

    /// <summary>Seller's fulfillment (shipping) business policy id.</summary>
    [JsonPropertyName("fulfillmentPolicyId")]
    public string? FulfillmentPolicyId { get; set; }

    /// <summary>Seller's payment business policy id.</summary>
    [JsonPropertyName("paymentPolicyId")]
    public string? PaymentPolicyId { get; set; }

    /// <summary>Seller's return business policy id.</summary>
    [JsonPropertyName("returnPolicyId")]
    public string? ReturnPolicyId { get; set; }

    /// <summary>Inventory location key the offer ships from (Sell Inventory "merchant location").</summary>
    [JsonPropertyName("merchantLocationKey")]
    public string? MerchantLocationKey { get; set; }

    /// <summary>Default eBay category id for new offers; a product-level MetadataJson categoryId wins.</summary>
    [JsonPropertyName("categoryId")]
    public string? CategoryId { get; set; }

    /// <summary>Content-Language header for inventory/offer writes (e.g. "de-DE"). Defaults to de-DE.</summary>
    [JsonPropertyName("contentLanguage")]
    public string ContentLanguage { get; set; } = "de-DE";

    public static EbayChannelConfig FromSalesChannel(SalesChannel salesChannel)
    {
        var config = string.IsNullOrEmpty(salesChannel.AdditionalConfigJson)
            ? new EbayChannelConfig()
            : JsonSerializer.Deserialize<EbayChannelConfig>(salesChannel.AdditionalConfigJson) ?? new EbayChannelConfig();

        config.MarketplaceId ??= salesChannel.MarketplaceId;
        return config;
    }

    /// <summary>The offer fields required to create and publish a listing; null when complete.</summary>
    public string? MissingOfferSettings()
    {
        var missing = new List<string>();
        if (string.IsNullOrEmpty(MarketplaceId)) missing.Add("marketplaceId");
        if (string.IsNullOrEmpty(FulfillmentPolicyId)) missing.Add("fulfillmentPolicyId");
        if (string.IsNullOrEmpty(PaymentPolicyId)) missing.Add("paymentPolicyId");
        if (string.IsNullOrEmpty(ReturnPolicyId)) missing.Add("returnPolicyId");
        if (string.IsNullOrEmpty(MerchantLocationKey)) missing.Add("merchantLocationKey");
        return missing.Count == 0 ? null : string.Join(", ", missing);
    }
}
