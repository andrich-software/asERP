using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiPrompt.Commands.AiPromptDelete;

public class AiPromptDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}