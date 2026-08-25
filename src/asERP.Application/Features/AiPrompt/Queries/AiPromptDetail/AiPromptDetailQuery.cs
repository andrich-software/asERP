using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Queries.AiPromptDetail;

public class AiPromptDetailQuery : IRequest<Result<AiPromptDetailDto>>
{
    public Guid Id { get; set; }
}
