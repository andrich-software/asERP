using asERP.Domain.Dtos.Manufacturer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerUpdate;

public class ManufacturerUpdateCommand : ManufacturerInputDto, IRequest<Result<Guid>>
{
}