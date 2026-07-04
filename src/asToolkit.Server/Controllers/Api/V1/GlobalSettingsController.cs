using Asp.Versioning;
using asToolkit.Application.Features.GlobalSettings.Commands.GlobalSettingsUpdate;
using asToolkit.Application.Features.GlobalSettings.Queries.GlobalSettingsList;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.GlobalSettings;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

/// <summary>
/// Superadmin-only key/value access to the global <c>Setting</c> rows (JWT, e-mail, telemetry,
/// company defaults, …). Secrets are masked on read and written via the encrypted path.
/// System OAuth apps keep their dedicated bundle endpoints in
/// <see cref="SystemOAuthSettingsController"/>.
/// </summary>
[ApiController]
[Authorize(Roles = "Superadmin")]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/superadmin/global-settings")]
public class GlobalSettingsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Result<List<GlobalSettingDto>>>> GetAll()
    {
        if (await EnsureSuperadminAccessAsync() is { } accessError)
        {
            return accessError;
        }

        var response = await mediator.Send(new GlobalSettingsListQuery());
        return response.ToActionResult();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Update([FromBody] GlobalSettingsUpdateInputDto input)
    {
        if (await EnsureSuperadminAccessAsync() is { } accessError)
        {
            return accessError;
        }

        var response = await mediator.Send(new GlobalSettingsUpdateCommand
        {
            Settings = input.Settings,
        });
        return response.ToActionResult();
    }

    /// <summary>
    /// Explicit in-action role check mirroring <see cref="SuperadminController"/>: the test host
    /// maps controllers with AllowAnonymous, so the [Authorize] attribute alone is not enforced
    /// there. Returns null when access is granted.
    /// </summary>
    private async Task<ActionResult?> EnsureSuperadminAccessAsync()
    {
        var authenticateResult = await HttpContext.AuthenticateAsync();
        if (authenticateResult is { Succeeded: true, Principal: not null })
        {
            HttpContext.User = authenticateResult.Principal;
        }

        if (!(User?.Identity?.IsAuthenticated ?? false))
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }

        if (!User.IsInRole("Superadmin"))
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        return null;
    }
}
