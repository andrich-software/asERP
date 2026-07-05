using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Queries.ReturnLabel;

public class ReturnLabelQuery : IRequest<Result<ShippingLabelDto>>
{
    public Guid Id { get; set; }
}
