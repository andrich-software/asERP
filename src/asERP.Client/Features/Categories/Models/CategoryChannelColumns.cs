using asERP.Domain.Enums;

namespace asERP.Client.Features.Categories.Models;

/// <summary>
/// Single source of truth for which sales-channel types get a checkbox column on the category
/// list page: the shop-like channels that carry a category tree. Marketplace channels (eBay,
/// Amazon) use their own fixed category systems and POS has none.
/// </summary>
public static class CategoryChannelColumns
{
    public static bool HasColumn(SalesChannelType type) =>
        type is SalesChannelType.AsShop
            or SalesChannelType.WooCommerce
            or SalesChannelType.WooCommerceDatabase
            or SalesChannelType.Shopware6;
}
