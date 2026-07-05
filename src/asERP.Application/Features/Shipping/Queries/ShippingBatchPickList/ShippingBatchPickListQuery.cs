using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingBatchPickList;

/// <summary>Combined pick list over several shipments (batch shipping run). Unknown ids are skipped.</summary>
public class ShippingBatchPickListQuery : IRequest<Result<ShippingLabelDto>>
{
    public IReadOnlyCollection<Guid> Ids { get; set; } = Array.Empty<Guid>();
}
