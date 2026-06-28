using asToolkit.Domain.Enums;
using asToolkit.SalesChannels.Abstractions;
using asToolkit.SalesChannels.Connectors.Common;

namespace asToolkit.SalesChannels.Connectors.Pos;

/// <summary>
/// Point-of-sale "channel" — fully internal, no remote API. Exists in the registry so the
/// orchestrator/UI can list every channel uniformly. <see cref="Capabilities"/> is
/// <see cref="SalesChannelCapabilities.None"/>; every method falls through to the base
/// no-op responses.
/// </summary>
public sealed class PosConnector : ConnectorBase
{
    public override SalesChannelType Type => SalesChannelType.PointOfSale;

    public override SalesChannelCapabilities Capabilities => SalesChannelCapabilities.None;
}
