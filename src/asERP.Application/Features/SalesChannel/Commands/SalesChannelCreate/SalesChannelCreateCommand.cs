using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelCreate;

/// <summary>
/// Command for creating a new sales channel in the system.
/// Inherits from SalesChannelInputDto to get all sales channel properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created sales channel wrapped in a Result.
/// </summary>
public class SalesChannelCreateCommand : SalesChannelInputDto, IRequest<Result<Guid>>
{
}