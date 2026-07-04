using Asp.Versioning;
using asToolkit.Application.Features.Sales.Commands.SalesCancel;
using asToolkit.Application.Features.Sales.Commands.SalesCreate;
using asToolkit.Application.Features.Sales.Commands.SalesDelete;
using asToolkit.Application.Features.Sales.Commands.SalesUpdate;
using asToolkit.Application.Features.Sales.Queries.SalesCustomerList;
using asToolkit.Application.Features.Sales.Queries.SalesDetail;
using asToolkit.Application.Features.Sales.Queries.SalesList;
using asToolkit.Application.Features.Sales.Queries.SalesNotPaidList;
using asToolkit.Application.Features.Sales.Queries.SalesReadyForDeliveryList;
using asToolkit.Application.Features.Sales.Queries.SalesShippableItems;
using asToolkit.Application.Features.Shipping.Queries.ShippingOptionsForSales;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class SalessController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<SalessController>
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SalesListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "", [FromQuery] Guid? salesChannelId = null)
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateSalesed Descending";
        }

        var saless = await mediator.Send(new SalesListQuery(pageNumber, pageSize, searchString, salesBy, salesChannelId));
        return Ok(saless);
    }

    // GET: api/v1/<SalessController>/customer/{customerId}
    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<PaginatedResult<SalesListDto>>> GetByCustomer(int customerId, int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateSalesed Descending";
        }

        var saless = await mediator.Send(new SalesCustomerListQuery(customerId, pageNumber, pageSize, searchString, salesBy));
        return Ok(saless);
    }

    // GET: api/v1/<SalessController>/ready-for-delivery
    [HttpGet("ready-for-delivery")]
    public async Task<ActionResult<PaginatedResult<SalesListDto>>> GetReadyForDelivery(int pageNumber = 0, int pageSize = 10, string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateSalesed Descending";
        }

        var saless = await mediator.Send(new SalesReadyForDeliveryListQuery(pageNumber, pageSize, salesBy));
        return Ok(saless);
    }

    // GET: api/v1/<SalessController>/not-paid
    [HttpGet("not-paid")]
    public async Task<ActionResult<PaginatedResult<SalesListDto>>> GetNotPaid(int pageNumber = 0, int pageSize = 10, string salesBy = "")
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "DateSalesed Descending";
        }

        var saless = await mediator.Send(new SalesNotPaidListQuery(pageNumber, pageSize, salesBy));
        return Ok(saless);
    }

    // GET: api/v1/<SalessController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SalesDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new SalesDetailQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/<SalessController>/5/shippable-items
    [HttpGet("{id:guid}/shippable-items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ShippableSalesItemDto>>> GetShippableItems(Guid id)
    {
        var response = await mediator.Send(new SalesShippableItemsQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // GET: api/v1/<SalessController>/5/shipping-options
    [HttpGet("{id:guid}/shipping-options")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ApplicableShippingRateDto>>> GetShippingOptions(Guid id)
    {
        var response = await mediator.Send(new ShippingOptionsForSalesQuery { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/<SalessController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(SalesCreateCommand salesCreateCommand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await mediator.Send(salesCreateCommand);
        return StatusCode((int)response.StatusCode, response);
    }

    // PUT: api/v1/<SalessController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, SalesUpdateCommand salesUpdateCommand)
    {
        // Check for ID mismatch
        if (salesUpdateCommand.Id != Guid.Empty && salesUpdateCommand.Id != id)
        {
            return BadRequest("ID mismatch between route and payload");
        }

        salesUpdateCommand.Id = id;
        var response = await mediator.Send(salesUpdateCommand);
        return StatusCode((int)response.StatusCode, response);
    }

    // POST: api/v1/<SalessController>/5/cancel
    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Cancel(Guid id)
    {
        var response = await mediator.Send(new SalesCancelCommand { Id = id });
        return StatusCode((int)response.StatusCode, response);
    }

    // DELETE: api/v1/<SalesController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteSalesCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}
