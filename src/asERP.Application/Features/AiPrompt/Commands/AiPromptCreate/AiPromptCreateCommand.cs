using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptCreate;

public class AiPromptCreateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}
