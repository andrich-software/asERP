using asERP.Application.Features.ShopDomain.Commands.ShopDomainCreate;
using asERP.Application.Features.ShopDomain.Commands.ShopDomainDelete;
using asERP.Application.Features.ShopDomain.Commands.ShopDomainUpdate;
using asERP.Application.Features.ShopDomain.Queries.ShopDomainList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Manages the inbound host bindings (domain + optional port) of asShop sales channels.
/// The bindings drive anonymous host-based storefront routing — hosts are globally unique
/// across tenants.
/// </summary>
[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class ShopDomainsController(IMediator mediator) : ControllerBase
{
    /// <summary>Lists the host bindings of one sales channel.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<List<ShopDomainListDto>>>> GetAll([FromQuery] Guid salesChannelId)
    {
        var response = await mediator.Send(new ShopDomainListQuery(salesChannelId));
        return response.ToActionResult();
    }

    /// <summary>Creates a host binding for an asShop sales channel.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Result<Guid>>> Create(ShopDomainCreateCommand command)
    {
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    /// <summary>Updates a host binding.</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result<Guid>>> Update(Guid id, ShopDomainUpdateCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Route id and body id do not match.");
        }

        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    /// <summary>Deletes a host binding.</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result<Guid>>> Delete(Guid id)
    {
        var response = await mediator.Send(new ShopDomainDeleteCommand { Id = id });
        return response.ToActionResult();
    }
}
