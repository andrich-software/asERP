using asERP.Domain.Services;
using Xunit;

namespace asERP.Server.Tests.Shop;

public class ShopHostNormalizerTests
{
    [Theory]
    [InlineData("testshop.de", "testshop.de")]
    [InlineData("TestShop.DE", "testshop.de")]
    [InlineData("  testshop.de  ", "testshop.de")]
    [InlineData("https://testshop.de", "testshop.de")]
    [InlineData("http://testshop.de/", "testshop.de")]
    [InlineData("testshop.de.", "testshop.de")]
    [InlineData("www.testshop.de", "www.testshop.de")]
    [InlineData("shop.example.co.uk", "shop.example.co.uk")]
    [InlineData("192.168.1.10", "192.168.1.10")]
    [InlineData("localhost", "localhost")]
    public void TryNormalize_ValidInput_ReturnsNormalizedHost(string input, string expected)
    {
        var success = ShopHostNormalizer.TryNormalize(input, out var normalized);

        Assert.True(success);
        Assert.Equal(expected, normalized);
    }

    [Fact]
    public void TryNormalize_IdnHost_ReturnsPunycode()
    {
        var success = ShopHostNormalizer.TryNormalize("stoffträume.de", out var normalized);

        Assert.True(success);
        Assert.Equal("xn--stofftrume-w5a.de", normalized);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("testshop.de:8080")]
    [InlineData("testshop.de/pfad")]
    [InlineData("https://testshop.de/pfad")]
    [InlineData("test shop.de")]
    [InlineData("http://")]
    [InlineData(".")]
    [InlineData("[::1]")]
    public void TryNormalize_InvalidInput_ReturnsFalse(string? input)
    {
        var success = ShopHostNormalizer.TryNormalize(input, out var normalized);

        Assert.False(success);
        Assert.Equal(string.Empty, normalized);
    }
}
