using asERP.Application.Features.GlobalSettings.Commands.GlobalSettingsUpdate;
using asERP.Application.Features.GlobalSettings.Queries.GlobalSettingsList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.GlobalSettings;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

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
        if (await this.EnsureSuperadminAccessAsync() is { } accessError)
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
        if (await this.EnsureSuperadminAccessAsync() is { } accessError)
        {
            return accessError;
        }

        var response = await mediator.Send(new GlobalSettingsUpdateCommand
        {
            Settings = input.Settings,
        });
        return response.ToActionResult();
    }
}
