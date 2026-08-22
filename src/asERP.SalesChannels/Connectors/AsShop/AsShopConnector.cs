using asERP.Domain.Enums;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.Common;

namespace asERP.SalesChannels.Connectors.AsShop;

/// <summary>
/// asShop storefront "channel" — fully internal, no remote API. Exists in the registry so the
/// orchestrator/UI can list every channel uniformly. Shop orders are created in-process through
/// the storefront checkout (never synced), and inbound requests are matched to the channel via
/// its ShopDomain host bindings. <see cref="Capabilities"/> is
/// <see cref="SalesChannelCapabilities.None"/>; every method falls through to the base
/// no-op responses.
/// </summary>
public sealed class AsShopConnector : ConnectorBase
{
    public override SalesChannelType Type => SalesChannelType.AsShop;

    public override SalesChannelCapabilities Capabilities => SalesChannelCapabilities.None;
}
