using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptCreate;

public class AiPromptCreateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}