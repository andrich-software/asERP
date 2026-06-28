using asToolkit.Domain.Dtos.TaxClass;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.TaxClass.Commands.TaxClassUpdate;

public class TaxClassUpdateCommand : TaxClassInputDto, IRequest<Result<Guid>>
{
}