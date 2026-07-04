using Asp.Versioning;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.ServerInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[AllowAnonymous]
[ApiVersion(1.0)]
// Explicit kebab-case route so the URL matches what the WASM client calls
// (/api/v1/server-info). The default [controller] token would expand to
// ServerInfo (no separator) and produce 404s.
[Route("/api/v{version:apiVersion}/server-info")]
public class ServerInfoController(IServerInfoService serverInfo) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ServerInfoResponseDto> Get() => Ok(new ServerInfoResponseDto
    {
        RegistrationEnabled = serverInfo.IsRegistrationEnabled,
        Version = serverInfo.Version
    });
}
