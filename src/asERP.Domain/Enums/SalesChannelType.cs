namespace asERP.Domain.Enums;

public enum SalesChannelType
{
    PointOfSale = 1,
    Shopware6 = 11,
    WooCommerce = 20,

    /// <summary>
    /// WooCommerce read/written directly via the shop's MySQL database instead of the REST API.
    /// Product images are still fetched over HTTP from the shop's public upload URLs.
    /// </summary>
    WooCommerceDatabase = 21,
    eBay = 30,
    Amazon = 40
}