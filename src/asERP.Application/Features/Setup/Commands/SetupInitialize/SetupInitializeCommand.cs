using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setup;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setup.Commands.SetupInitialize;

/// <summary>
/// One-shot initial server setup: creates the first Superadmin account and the first
/// tenant, then marks the setup as completed. Returns the new tenant's id.
/// </summary>
public class SetupInitializeCommand : InitialSetupInputDto, IRequest<Result<Guid>>
{
}
