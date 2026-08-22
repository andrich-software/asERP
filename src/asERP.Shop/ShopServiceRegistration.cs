using asERP.Application;
using asERP.Shop.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Shop;

public static class ShopServiceRegistration
{
    /// <summary>
    /// Registers the asShop storefront: Razor Components rendering, the host resolver and the
    /// notification handlers of this assembly. No background services — safe to register in
    /// every environment including Testing.
    /// </summary>
    public static IServiceCollection AddShopServices(this IServiceCollection services)
    {
        // Static SSR only for now; interactive server islands (cart/filter/search) come later
        // and will add AddInteractiveServerComponents here.
        services.AddRazorComponents();

        services.AddSingleton<IShopHostResolver, ShopHostResolver>();

        // Notification handlers in this assembly (resolver invalidation) — mirror of the
        // SalesChannels registration.
        services.RegisterHandlersFromAssembly(typeof(ShopServiceRegistration).Assembly);

        return services;
    }
}
