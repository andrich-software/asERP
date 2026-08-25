using asERP.Client.Presentation;
using asERP.Domain.Enums;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for <see cref="SalesChannelSyncSettingsVisibility.HasSyncSettings"/> — the shared rule
/// that hides the import/export sync section on the edit and detail pages for the internal
/// channel types (PointOfSale has no sync; asShop keeps every direction always on).
/// </summary>
public class SalesChannelSyncSettingsVisibilityTests
{
    [TestCase(SalesChannelType.PointOfSale)]
    [TestCase(SalesChannelType.AsShop)]
    public void InternalTypes_HaveNoSyncSettings(SalesChannelType type)
    {
        Assert.That(SalesChannelSyncSettingsVisibility.HasSyncSettings(type), Is.False);
    }

    [TestCase(SalesChannelType.Shopware6)]
    [TestCase(SalesChannelType.WooCommerce)]
    [TestCase(SalesChannelType.WooCommerceDatabase)]
    [TestCase(SalesChannelType.eBay)]
    [TestCase(SalesChannelType.Amazon)]
    public void ExternalTypes_HaveSyncSettings(SalesChannelType type)
    {
        Assert.That(SalesChannelSyncSettingsVisibility.HasSyncSettings(type), Is.True);
    }
}
