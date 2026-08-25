using asERP.Application.Mediator;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassUpdate;

public class TaxClassUpdateCommand : TaxClassInputDto, IRequest<Result<Guid>>
{
}
