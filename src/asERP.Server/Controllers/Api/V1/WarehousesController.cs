using asERP.Application.Features.Warehouse.Commands.WarehouseCreate;
using asERP.Application.Features.Warehouse.Commands.WarehouseDelete;
using asERP.Application.Features.Warehouse.Commands.WarehouseUpdate;
using asERP.Application.Features.Warehouse.Queries.WarehouseDetail;
using asERP.Application.Features.Warehouse.Queries.WarehouseList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class WarehousesController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<WarehousesController>
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<WarehouseListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        if (string.IsNullOrEmpty(sortBy))
        {
            sortBy = "DateCreated Descending";
        }

        var response = await mediator.Send(new WarehouseListQuery(pageNumber, pageSize, searchString, sortBy));
        return response.ToActionResult();
    }

    // GET: api/v1/<WarehousesController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WarehouseDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new WarehouseDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // POST: api/v1/<WarehousesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(WarehouseCreateCommand warehouseCreateCommand)
    {
        var response = await mediator.Send(warehouseCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<WarehousesController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<WarehouseDetailDto>> Update(Guid id, WarehouseUpdateCommand warehouseUpdateCommand)
    {
        warehouseUpdateCommand.Id = id;
        var response = await mediator.Send(warehouseUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<WarehousesController>/5?newWarehouseId=2
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id, [FromQuery] Guid? newWarehouseId = null)
    {
        var command = new WarehouseDeleteCommand { Id = id, NewWarehouseId = newWarehouseId };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
