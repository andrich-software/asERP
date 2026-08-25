using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Commands.AiModelUpdate;

public class AiModelUpdateCommand : AiModelInputDto, IRequest<Result<Guid>>
{
}
