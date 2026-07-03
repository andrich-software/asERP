using asToolkit.Domain.Enums;

namespace asToolkit.Shipping.Abstractions;

public interface IShippingCarrierConnectorRegistry
{
    IShippingCarrierConnector? Resolve(ShippingProviderType type);
    IShippingCarrierConnector Get(ShippingProviderType type);
    IEnumerable<IShippingCarrierConnector> All();
}
