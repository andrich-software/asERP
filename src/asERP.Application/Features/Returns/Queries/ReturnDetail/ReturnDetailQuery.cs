using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Queries.ReturnDetail;

public class ReturnDetailQuery : IRequest<Result<ReturnShipmentDetailDto>>
{
    public Guid Id { get; set; }
}
