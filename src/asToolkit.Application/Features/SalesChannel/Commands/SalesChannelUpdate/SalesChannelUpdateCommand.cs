using asToolkit.Domain.Dtos.SalesChannel;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.SalesChannel.Commands.SalesChannelUpdate;

public class SalesChannelUpdateCommand : SalesChannelInputDto, IRequest<Result<Guid>>
{
}