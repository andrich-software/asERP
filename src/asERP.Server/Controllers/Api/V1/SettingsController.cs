using asERP.Application.Features.Setting.Commands.SettingCreate;
using asERP.Application.Features.Setting.Commands.SettingDelete;
using asERP.Application.Features.Setting.Commands.SettingUpdate;
using asERP.Application.Features.Setting.Queries.SettingDetail;
using asERP.Application.Features.Setting.Queries.SettingList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
// Superadmin-only: the raw rows include credentials (Jwt.Key, SMTP password, …) that must not
// be readable by every authenticated user. The Client uses the masked
// /superadmin/global-settings endpoint instead.
[Authorize(Roles = "Superadmin")]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class SettingsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<SettingsController>
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SettingListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            sortBy = "DateCreated Descending";
        }

        var response = await mediator.Send(new SettingListQuery(pageNumber, pageSize, searchString, sortBy));
        return response.ToActionResult();
    }

    // GET: api/v1/<SettingsController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SettingDetailDto>> GetDetails(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest(Result<SettingDetailDto>.Invalid(ErrorCodes.Setting.Invalid, "Invalid GUID format"));
        }

        var response = await mediator.Send(new SettingDetailQuery { Id = guidId });
        return response.ToActionResult();
    }

    // POST: api/v1/<SettingsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(SettingCreateCommand settingCreateCommand)
    {
        var response = await mediator.Send(settingCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<SettingsController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Result<Guid>>> Update(string id, SettingUpdateCommand settingUpdateCommand)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest(Result<Guid>.Invalid(ErrorCodes.Setting.Invalid, "Invalid GUID format"));
        }

        // Validate that URL ID matches the ID in the request body (if provided)
        if (settingUpdateCommand.Id != Guid.Empty && settingUpdateCommand.Id != guidId)
        {
            return BadRequest(Result<Guid>.Invalid(ErrorCodes.Setting.Invalid, "ID in URL does not match ID in request body"));
        }

        settingUpdateCommand.Id = guidId;
        var response = await mediator.Send(settingUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<SettingsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            return BadRequest(Result.Fail("Invalid GUID format"));
        }

        var command = new SettingDeleteCommand { Id = guidId };
        var result = await mediator.Send(command);

        return result.ToActionResult();
    }
}
