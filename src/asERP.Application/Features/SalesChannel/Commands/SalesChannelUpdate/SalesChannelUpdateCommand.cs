using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelUpdate;

public class SalesChannelUpdateCommand : SalesChannelInputDto, IRequest<Result<Guid>>
{
}