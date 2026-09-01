using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setup;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setup.Commands.SetupInitialize;

/// <summary>
/// One-shot initial server setup: creates the first Superadmin account and the first
/// tenant, then marks the setup as completed. Returns the new tenant's id.
/// </summary>
/// <remarks>
/// Deliberately validated inside the handler, not by the mediator: the endpoint is anonymous and
/// must answer 403 for every payload once setup is done. Validating first would let the
/// email-uniqueness rule reveal to anyone which accounts exist.
/// </remarks>
public class SetupInitializeCommand : InitialSetupInputDto, IRequest<Result<Guid>>, ISkipPipelineValidation
{
}
