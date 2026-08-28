using asERP.SalesChannels.Models.WooCommerce;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Pure parsing/formatting rules shared by both WooCommerce connectors: which order meta key holds
/// the tracking numbers, and how a stored value maps to individual numbers and back.
/// </summary>
public class WooShipmentTrackingTests
{
    [Fact]
    public void ResolveMetaKey_WithoutConfig_UsesGermanMarketDefault()
    {
        Assert.Equal(WooShipmentTracking.DefaultMetaKey, WooShipmentTracking.ResolveMetaKey(null));
        Assert.Equal(WooShipmentTracking.DefaultMetaKey, WooShipmentTracking.ResolveMetaKey(string.Empty));
        Assert.Equal(WooShipmentTracking.DefaultMetaKey, WooShipmentTracking.ResolveMetaKey("{\"host\":\"db.example.com\"}"));
    }

    [Fact]
    public void ResolveMetaKey_ReadsConfiguredKey()
    {
        var json = "{\"host\":\"db.example.com\",\"shipmentTrackingMetaKey\":\"  _my_tracking  \"}";

        Assert.Equal("_my_tracking", WooShipmentTracking.ResolveMetaKey(json));
    }

    [Fact]
    public void ResolveMetaKey_MalformedConfig_FallsBackInsteadOfThrowing()
    {
        Assert.Equal(WooShipmentTracking.DefaultMetaKey, WooShipmentTracking.ResolveMetaKey("{not json"));
        Assert.Equal(WooShipmentTracking.DefaultMetaKey, WooShipmentTracking.ResolveMetaKey("\"just a string\""));
    }

    [Fact]
    public void ParseNumbers_SplitsAndTrimsDelimitedValues()
    {
        var numbers = WooShipmentTracking.ParseNumbers("00340434666768541089, 00340434666768541072|CE737758155DE");

        Assert.Equal(
            new[] { "00340434666768541089", "00340434666768541072", "CE737758155DE" },
            numbers);
    }

    [Fact]
    public void ParseNumbers_SingleValue_IsReturnedAsIs()
    {
        Assert.Equal(new[] { "00340434666768541089" }, WooShipmentTracking.ParseNumbers("00340434666768541089"));
    }

    [Fact]
    public void ParseNumbers_DeduplicatesRepeatedNumbers()
    {
        Assert.Equal(new[] { "ABC123" }, WooShipmentTracking.ParseNumbers("ABC123,ABC123"));
    }

    [Fact]
    public void ParseNumbers_PhpSerializedValue_YieldsNothingRatherThanGuessing()
    {
        // Format used by the WooCommerce Shipment Tracking plugin family. Picking strings out of it
        // would return provider names and dates just as happily as tracking numbers.
        var serialized = "a:1:{i:0;a:2:{s:13:\"tracking_provider\";s:3:\"dhl\";s:15:\"tracking_number\";s:6:\"ABC123\";}}";

        Assert.Empty(WooShipmentTracking.ParseNumbers(serialized));
        Assert.True(WooShipmentTracking.IsPhpSerialized(serialized));
    }

    [Fact]
    public void ParseNumbers_EmptyValue_YieldsNothing()
    {
        Assert.Empty(WooShipmentTracking.ParseNumbers(null));
        Assert.Empty(WooShipmentTracking.ParseNumbers("   "));
    }

    [Fact]
    public void FormatNumbers_JoinsTrimmedDistinctValues()
    {
        var value = WooShipmentTracking.FormatNumbers(new[] { " ABC123 ", "DEF456", "ABC123", "  " });

        Assert.Equal("ABC123, DEF456", value);
    }

    [Fact]
    public void FormatNumbers_RoundTripsThroughParseNumbers()
    {
        var original = new[] { "00340434666768541089", "CE737758155DE" };

        Assert.Equal(original, WooShipmentTracking.ParseNumbers(WooShipmentTracking.FormatNumbers(original)));
    }
}
