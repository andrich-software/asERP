using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Manufacturer.Commands.ManufacturerUpdate;

public class ManufacturerUpdateCommand : ManufacturerInputDto, IRequest<Result<Guid>>
{
}