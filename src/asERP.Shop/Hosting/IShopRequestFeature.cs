using asERP.Domain.Dtos.Shop;

namespace asERP.Shop.Hosting;

/// <summary>
/// Marks an HTTP request as belonging to a shop host. Set by <see cref="ShopHostMiddleware"/>
/// once the Host header resolved to an enabled AsShop channel; downstream (security headers,
/// TenantMiddleware skip, exception handling, page rendering) branches on its presence.
/// </summary>
public interface IShopRequestFeature
{
    ShopHostBindingRef Binding { get; }
}

public sealed class ShopRequestFeature(ShopHostBindingRef binding) : IShopRequestFeature
{
    public ShopHostBindingRef Binding { get; } = binding;
}
