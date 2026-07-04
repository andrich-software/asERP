using asERP.Domain.Enums;

namespace asERP.Shipping.Abstractions;

public sealed class ShippingCarrierConnectorRegistry : IShippingCarrierConnectorRegistry
{
    private readonly Dictionary<ShippingProviderType, IShippingCarrierConnector> _byType;

    public ShippingCarrierConnectorRegistry(IEnumerable<IShippingCarrierConnector> connectors)
    {
        _byType = connectors.ToDictionary(c => c.Type);
    }

    public IShippingCarrierConnector? Resolve(ShippingProviderType type)
        => _byType.TryGetValue(type, out var connector) ? connector : null;

    public IShippingCarrierConnector Get(ShippingProviderType type)
        => Resolve(type) ?? throw new InvalidOperationException(
            $"No connector registered for ShippingProviderType.{type}. " +
            "Did you forget to add it to ShippingServiceRegistration?");

    public IEnumerable<IShippingCarrierConnector> All() => _byType.Values;
}
