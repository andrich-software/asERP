using asERP.Application.Features.Setup.Commands.SetupInitialize;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Anonymous one-shot endpoint for the initial server setup: creates the first Superadmin
/// together with the first tenant. The handler refuses (403) as soon as the setup was
/// completed or any user account exists, so the endpoint is only a door on an empty server.
/// </summary>
[ApiController]
[AllowAnonymous]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/setup")]
[EnableRateLimiting("auth")]
public class SetupController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Result<Guid>>> Run(SetupInitializeCommand command)
    {
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
