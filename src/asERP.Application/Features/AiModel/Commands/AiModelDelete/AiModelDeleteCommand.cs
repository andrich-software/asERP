using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Commands.AiModelDelete;

public class AiModelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
