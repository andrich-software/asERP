using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptDelete;

public class AiPromptDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}