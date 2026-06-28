using Asp.Versioning;
using asToolkit.Application.Features.Warehouse.Commands.WarehouseCreate;
using asToolkit.Application.Features.Warehouse.Commands.WarehouseDelete;
using asToolkit.Application.Features.Warehouse.Commands.WarehouseUpdate;
using asToolkit.Application.Features.Warehouse.Queries.WarehouseDetail;
using asToolkit.Application.Features.Warehouse.Queries.WarehouseList;
using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class WarehousesController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<WarehousesController>
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<WarehouseListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateCreated Descending";
        }

        var response = await mediator.Send(new WarehouseListQuery(pageNumber, pageSize, searchString, salesBy));
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/<WarehousesController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WarehouseDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new WarehouseDetailQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/<WarehousesController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create(WarehouseCreateCommand warehouseCreateCommand)
    {
        var response = await mediator.Send(warehouseCreateCommand);
        return StatusCode((int)response.StatusCode, response);
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
        return StatusCode((int)response.StatusCode, response);
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
        return StatusCode((int)response.StatusCode, response);
    }
}
