using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnReceive;

public class ReturnReceiveCommand : ReturnReceiveInputDto, IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
