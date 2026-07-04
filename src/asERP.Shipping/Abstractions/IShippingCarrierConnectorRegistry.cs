using asERP.Domain.Enums;

namespace asERP.Shipping.Abstractions;

public interface IShippingCarrierConnectorRegistry
{
    IShippingCarrierConnector? Resolve(ShippingProviderType type);
    IShippingCarrierConnector Get(ShippingProviderType type);
    IEnumerable<IShippingCarrierConnector> All();
}
