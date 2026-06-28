using asToolkit.Domain.Dtos.AiPrompt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiPrompt.Commands.AiPromptUpdate;

public class AiPromptUpdateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}