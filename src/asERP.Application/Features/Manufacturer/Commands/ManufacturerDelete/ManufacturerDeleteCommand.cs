using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerDelete;

public class ManufacturerDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
