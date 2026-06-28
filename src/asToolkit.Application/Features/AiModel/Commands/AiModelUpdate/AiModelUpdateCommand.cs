using asToolkit.Domain.Dtos.AiModel;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiModel.Commands.AiModelUpdate;

public class AiModelUpdateCommand : AiModelInputDto, IRequest<Result<Guid>>
{
}