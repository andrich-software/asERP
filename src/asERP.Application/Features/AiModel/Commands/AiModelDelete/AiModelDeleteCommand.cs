using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiModel.Commands.AiModelDelete;

public class AiModelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}