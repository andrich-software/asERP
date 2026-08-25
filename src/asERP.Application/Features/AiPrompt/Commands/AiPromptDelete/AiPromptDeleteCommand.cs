using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptDelete;

public class AiPromptDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
