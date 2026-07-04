using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Commands.ShippingLabelRetry;

/// <summary>Re-requests a carrier label for a shipment whose label creation failed or dead-lettered.</summary>
public class ShippingLabelRetryCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
