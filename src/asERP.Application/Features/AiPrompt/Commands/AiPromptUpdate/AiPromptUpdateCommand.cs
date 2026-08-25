using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptUpdate;

public class AiPromptUpdateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}
