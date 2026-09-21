using asERP.Application.Services;

namespace asERP.Application.Features.SalesChannel;

/// <summary>
/// Secret rules for <c>SalesChannel.AdditionalConfigJson</c>, kept in one place so the detail
/// query and the create/update commands can never disagree about which keys of the blob are
/// credentials. The sibling of <c>ShippingProviderConfigSecrets</c> for the channel connectors.
/// </summary>
public static class SalesChannelConfigSecrets
{
    /// <summary>
    /// The credentials the channel configs carry today: the Shopware 6 integration secret
    /// (<c>Shopware6ChannelConfig</c>, sent as <c>client_secret</c> to the Admin API) and the
    /// Amazon LWA app secret (<c>AmazonChannelConfig</c>).
    /// </summary>
    private static readonly string[] SecretKeys = ["apiClientSecret", "lwaClientSecret"];

    /// <summary>
    /// Every remaining key of the channel configs (<c>asERP.SalesChannels/Models/</c>:
    /// Shopware6/Amazon/Ebay/WooCommerceDatabaseChannelConfig and the WooCommerce tracking meta
    /// key). Listing them keeps the redactor's name-based catch-all from masking a setting the
    /// connectors need: <c>merchantLocationKey</c> and <c>shipmentTrackingMetaKey</c> end in "Key"
    /// but are plain identifiers, not credentials. The connectors spell their keys in camelCase
    /// (unlike the carrier configs) — the redactor matches case-insensitively either way.
    /// </summary>
    private static readonly string[] PlainKeys =
    [
        "apiClientId", "languageId",
        "lwaClientId", "sellerId", "region", "useSandbox",
        "marketplaceId", "fulfillmentPolicyId", "paymentPolicyId", "returnPolicyId",
        "merchantLocationKey", "categoryId", "contentLanguage",
        "shipmentTrackingMetaKey",
        "host", "port", "database", "tablePrefix", "allowPrivateHost", "allowInsecureTransport"
    ];

    public static ConfigJsonSecretRedactor Redactor { get; } = new(SecretKeys, PlainKeys);
}
