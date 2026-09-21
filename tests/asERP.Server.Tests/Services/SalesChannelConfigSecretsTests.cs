using System.Text.Json.Nodes;
using asERP.Application.Features.SalesChannel;
using asERP.Application.Services;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// Unit tests for the key list of <c>SalesChannel.AdditionalConfigJson</c>: the two connector
/// credentials never leave the server, and every other key of the channel configs survives the
/// redactor's name-based catch-all.
/// </summary>
public class SalesChannelConfigSecretsTests
{
    private static readonly ConfigJsonSecretRedactor Channel = SalesChannelConfigSecrets.Redactor;

    private const string Shopware6Config =
        """{"apiClientId":"SWIAxxxx","apiClientSecret":"live-shopware-secret","languageId":"2fbb5fe2e29a"}""";

    private const string AmazonConfig =
        """{"lwaClientId":"amzn1.application-oa2-client.x","lwaClientSecret":"live-amazon-secret","sellerId":"A1B2C3","region":"eu"}""";

    private static string? Value(string? json, string key)
        => (JsonNode.Parse(json!) as JsonObject)?[key]?.GetValue<string>();

    [Fact]
    public void Redact_HidesTheShopwareIntegrationSecret()
    {
        var redacted = Channel.Redact(Shopware6Config);

        Assert.Equal(ConfigJsonSecretRedactor.RedactedValue, Value(redacted, "apiClientSecret"));
        Assert.DoesNotContain("live-shopware-secret", redacted);
        Assert.Equal("SWIAxxxx", Value(redacted, "apiClientId"));
        Assert.Equal("2fbb5fe2e29a", Value(redacted, "languageId"));
    }

    [Fact]
    public void Redact_HidesTheAmazonLwaSecret()
    {
        var redacted = Channel.Redact(AmazonConfig);

        Assert.Equal(ConfigJsonSecretRedactor.RedactedValue, Value(redacted, "lwaClientSecret"));
        Assert.DoesNotContain("live-amazon-secret", redacted);
        Assert.Equal("amzn1.application-oa2-client.x", Value(redacted, "lwaClientId"));
        Assert.Equal("A1B2C3", Value(redacted, "sellerId"));
    }

    [Fact]
    public void Redact_LeavesTheEbayAndWooSettingsUntouched()
    {
        const string json =
            """{"merchantLocationKey":"WAREHOUSE-1","shipmentTrackingMetaKey":"_custom_tracking","host":"db.example.com","port":3306}""";

        Assert.Equal(json, Channel.Redact(json));
    }

    [Fact]
    public void Merge_WithPlaceholder_KeepsTheStoredSecret()
    {
        var merged = Channel.Merge(Channel.Redact(Shopware6Config), Shopware6Config);

        Assert.Equal("live-shopware-secret", Value(merged, "apiClientSecret"));
        Assert.Equal("SWIAxxxx", Value(merged, "apiClientId"));
    }

    [Theory]
    [InlineData("apiClientSecret")]
    [InlineData("lwaClientSecret")]
    [InlineData("ApiClientSecret")]
    [InlineData("LWACLIENTSECRET")]
    public void IsSecretKey_CoversBothConnectorSecretsWhateverTheCasing(string key)
        => Assert.True(Channel.IsSecretKey(key));

    /// <summary>
    /// <c>merchantLocationKey</c> and <c>shipmentTrackingMetaKey</c> end in "Key" and would be
    /// swallowed by the name-based catch-all if they were missing from the plain list — the eBay
    /// offer and the WooCommerce tracking write-back would silently break.
    /// </summary>
    [Theory]
    [InlineData("apiClientId")]
    [InlineData("languageId")]
    [InlineData("lwaClientId")]
    [InlineData("sellerId")]
    [InlineData("region")]
    [InlineData("useSandbox")]
    [InlineData("marketplaceId")]
    [InlineData("fulfillmentPolicyId")]
    [InlineData("paymentPolicyId")]
    [InlineData("returnPolicyId")]
    [InlineData("merchantLocationKey")]
    [InlineData("categoryId")]
    [InlineData("contentLanguage")]
    [InlineData("shipmentTrackingMetaKey")]
    [InlineData("host")]
    [InlineData("port")]
    [InlineData("database")]
    [InlineData("tablePrefix")]
    [InlineData("allowPrivateHost")]
    [InlineData("allowInsecureTransport")]
    public void IsSecretKey_NeverCoversAKnownChannelSetting(string key)
        => Assert.False(Channel.IsSecretKey(key));
}
