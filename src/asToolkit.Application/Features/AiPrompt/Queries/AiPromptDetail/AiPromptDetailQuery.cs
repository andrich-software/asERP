using asToolkit.Domain.Dtos.AiPrompt;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiPrompt.Queries.AiPromptDetail;

public class AiPromptDetailQuery : IRequest<Result<AiPromptDetailDto>>
{
    public Guid Id { get; set; }
}