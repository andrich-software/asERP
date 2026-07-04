using Asp.Versioning;
using asERP.Application.Features.TenantOAuthAppSettings.Commands.TenantOAuthAppSettingsDelete;
using asERP.Application.Features.TenantOAuthAppSettings.Commands.TenantOAuthAppSettingsUpsert;
using asERP.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsDetail;
using asERP.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.TenantOAuthAppSettings;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Per-tenant OAuth Developer-App credentials. Sibling of <c>TenantEmailSettingsController</c>.
/// Field-level merge with the system-level <c>OAuth.{Provider}.*</c> Setting rows happens in
/// <c>OAuthAppSettingsService</c> when the orchestration layer asks for effective credentials.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/tenant/oauth-app-settings")]
public class TenantOAuthAppSettingsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<List<TenantOAuthAppSettingsListDto>>>> List()
    {
        var response = await mediator.Send(new TenantOAuthAppSettingsListQuery());
        return response.ToActionResult();
    }

    [HttpGet("{provider}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<TenantOAuthAppSettingsDetailDto>>> Detail(string provider)
    {
        if (!Enum.TryParse<SalesChannelType>(provider, ignoreCase: true, out var providerEnum))
        {
            return BadRequest(new { Error = $"Unknown provider '{provider}'." });
        }

        var response = await mediator.Send(new TenantOAuthAppSettingsDetailQuery { Provider = providerEnum });
        return response.ToActionResult();
    }

    /// <summary>
    /// Upsert (create-or-update) the tenant override for the given provider. The route's
    /// <c>{provider}</c> wins over <see cref="TenantOAuthAppSettingsInputDto.Provider"/> if they
    /// disagree — this is friendlier to typo'd payloads.
    /// </summary>
    [HttpPut("{provider}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<Guid>>> Upsert(string provider, [FromBody] TenantOAuthAppSettingsInputDto input)
    {
        if (!Enum.TryParse<SalesChannelType>(provider, ignoreCase: true, out var providerEnum))
        {
            return BadRequest(new { Error = $"Unknown provider '{provider}'." });
        }

        var response = await mediator.Send(new TenantOAuthAppSettingsUpsertCommand
        {
            Provider = providerEnum,
            IsActive = input.IsActive,
            ClientId = input.ClientId,
            ClientSecret = input.ClientSecret,
            RedirectUri = input.RedirectUri,
            RuName = input.RuName,
            Scopes = input.Scopes,
            UseSandbox = input.UseSandbox,
        });
        return response.ToActionResult();
    }

    [HttpDelete("{provider}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(string provider)
    {
        if (!Enum.TryParse<SalesChannelType>(provider, ignoreCase: true, out var providerEnum))
        {
            return BadRequest(new { Error = $"Unknown provider '{provider}'." });
        }

        var response = await mediator.Send(new TenantOAuthAppSettingsDeleteCommand { Provider = providerEnum });
        return response.ToActionResult();
    }
}
