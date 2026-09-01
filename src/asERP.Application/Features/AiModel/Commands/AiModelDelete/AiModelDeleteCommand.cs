using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Commands.AiModelDelete;

/// <summary>
/// Not validated by the mediator: `AIModelsController.Delete` discards the result and always answers
/// 204, so the validator's "AiModel not found" rule has never reached a client. Letting the pipeline
/// throw would turn this deliberately idempotent DELETE into a 400.
/// </summary>
public class AiModelDeleteCommand : IRequest<Result<Guid>>, ISkipPipelineValidation
{
    public Guid Id { get; set; }
}
