using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptUpdate;

public class AiPromptUpdateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}