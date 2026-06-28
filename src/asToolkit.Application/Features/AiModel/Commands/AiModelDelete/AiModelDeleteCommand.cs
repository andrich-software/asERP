using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.AiModel.Commands.AiModelDelete;

public class AiModelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}