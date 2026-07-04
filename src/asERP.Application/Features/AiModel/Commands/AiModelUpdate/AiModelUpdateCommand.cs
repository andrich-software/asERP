using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiModel.Commands.AiModelUpdate;

public class AiModelUpdateCommand : AiModelInputDto, IRequest<Result<Guid>>
{
}