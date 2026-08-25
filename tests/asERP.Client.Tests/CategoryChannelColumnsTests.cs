using asERP.Client.Features.Categories.Models;
using asERP.Domain.Enums;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="CategoryChannelColumns.HasColumn"/> — the single source of truth for
/// which sales-channel types get a checkbox column on the category matrix. Shop-like channels
/// (asShop, WooCommerce in both transports, Shopware 6) carry a category tree; marketplaces
/// (eBay, Amazon) use fixed category systems and POS has none, so they must never get a column.
/// </summary>
public class CategoryChannelColumnsTests
{
    [TestCase(SalesChannelType.AsShop)]
    [TestCase(SalesChannelType.WooCommerce)]
    [TestCase(SalesChannelType.WooCommerceDatabase)]
    [TestCase(SalesChannelType.Shopware6)]
    public void ShopLikeTypes_GetAColumn(SalesChannelType type)
        => Assert.That(CategoryChannelColumns.HasColumn(type), Is.True);

    [TestCase(SalesChannelType.PointOfSale)]
    [TestCase(SalesChannelType.eBay)]
    [TestCase(SalesChannelType.Amazon)]
    public void MarketplaceAndPosTypes_GetNoColumn(SalesChannelType type)
        => Assert.That(CategoryChannelColumns.HasColumn(type), Is.False);
}
