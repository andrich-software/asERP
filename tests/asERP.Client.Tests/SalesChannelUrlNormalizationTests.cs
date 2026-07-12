using asERP.Client.Features.SalesChannels.Models;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for the URL normalizers on <see cref="SalesChannelEditModel"/>: the WooCommerce REST
/// variant appends <c>/wp-json/wc/v3</c> to whatever the user typed, the database variant keeps
/// the plain shop base URL (image downloads) and strips a pasted REST path. Both mirror
/// ServerUrlUtil's scheme/trailing-slash handling and must be idempotent — save reflects the
/// normalized value back into the field, so a second save runs them again.
/// </summary>
public class SalesChannelUrlNormalizationTests
{
    [TestCase("shop.example.org", "https://shop.example.org/wp-json/wc/v3")]
    [TestCase("  shop.example.org/  ", "https://shop.example.org/wp-json/wc/v3")]
    [TestCase("http://shop.example.org", "http://shop.example.org/wp-json/wc/v3")]
    [TestCase("example.org/shop", "https://example.org/shop/wp-json/wc/v3")]
    [TestCase("https://shop.example.org/wp-json/wc/v3", "https://shop.example.org/wp-json/wc/v3")]
    [TestCase("https://shop.example.org/wp-json/wc/v3/", "https://shop.example.org/wp-json/wc/v3")]
    [TestCase("https://shop.example.org/WP-JSON/WC/V3", "https://shop.example.org/WP-JSON/WC/V3")]
    [TestCase("https://shop.example.org/wp-json/wc/v3/products", "https://shop.example.org/wp-json/wc/v3/products")]
    public void NormalizeWooCommerceUrl_AppendsRestPathOnce(string input, string expected)
    {
        Assert.That(SalesChannelEditModel.NormalizeWooCommerceUrl(input), Is.EqualTo(expected));
    }

    [Test]
    public void NormalizeWooCommerceUrl_IsIdempotent()
    {
        var once = SalesChannelEditModel.NormalizeWooCommerceUrl("shop.example.org");
        Assert.That(SalesChannelEditModel.NormalizeWooCommerceUrl(once), Is.EqualTo(once));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void NormalizeWooCommerceUrl_EmptyInput_IsReturnedAsIs(string? input)
    {
        Assert.That(SalesChannelEditModel.NormalizeWooCommerceUrl(input!), Is.EqualTo(input));
    }

    [TestCase("shop.example.org", "https://shop.example.org")]
    [TestCase("  shop.example.org/  ", "https://shop.example.org")]
    [TestCase("http://shop.example.org/", "http://shop.example.org")]
    [TestCase("shop.example.org/wp-json/wc/v3", "https://shop.example.org")]
    [TestCase("https://shop.example.org/wp-json/wc/v3/", "https://shop.example.org")]
    [TestCase("HTTPS://shop.example.org/WP-JSON/WC/V3", "HTTPS://shop.example.org")]
    public void NormalizeShopBaseUrl_KeepsBaseAndStripsRestPath(string input, string expected)
    {
        Assert.That(SalesChannelEditModel.NormalizeShopBaseUrl(input), Is.EqualTo(expected));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void NormalizeShopBaseUrl_EmptyInput_IsReturnedAsIs(string? input)
    {
        Assert.That(SalesChannelEditModel.NormalizeShopBaseUrl(input!), Is.EqualTo(input));
    }
}
