using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiPrompt.Queries.AiPromptDetail;

public class AiPromptDetailQuery : IRequest<Result<AiPromptDetailDto>>
{
    public Guid Id { get; set; }
}