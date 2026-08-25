using asERP.Application.Mediator;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerUpdate;

public class ManufacturerUpdateCommand : ManufacturerInputDto, IRequest<Result<Guid>>
{
}
