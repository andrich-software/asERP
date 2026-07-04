using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassUpdate;

public class TaxClassUpdateCommand : TaxClassInputDto, IRequest<Result<Guid>>
{
}