using asERP.Application.Mediator;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelUpdate;

public class SalesChannelUpdateCommand : SalesChannelInputDto, IRequest<Result<Guid>>
{
}
