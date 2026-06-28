using asToolkit.Domain.Dtos.AiPrompt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiPrompt.Commands.AiPromptCreate;

public class AiPromptCreateCommand : AiPromptInputDto, IRequest<Result<Guid>>
{
}