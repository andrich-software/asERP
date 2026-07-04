using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerDelete;

public class ManufacturerDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}