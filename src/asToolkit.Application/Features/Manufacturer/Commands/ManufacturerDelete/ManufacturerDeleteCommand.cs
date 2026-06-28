using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Manufacturer.Commands.ManufacturerDelete;

public class ManufacturerDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}