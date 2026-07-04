using Asp.Versioning;
using asToolkit.Application.Features.Shipping.Commands.ShippingCancel;
using asToolkit.Application.Features.Shipping.Commands.ShippingCreate;
using asToolkit.Application.Features.Shipping.Commands.ShippingDelete;
using asToolkit.Application.Features.Shipping.Commands.ShippingLabelRetry;
using asToolkit.Application.Features.Shipping.Commands.ShippingUpdate;
using asToolkit.Application.Features.Shipping.Queries.ShippingDetail;
using asToolkit.Application.Features.Shipping.Queries.ShippingLabel;
using asToolkit.Application.Features.Shipping.Queries.ShippingList;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/[controller]")]
public class ShippingsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<ShippingsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<ShipmentListItemDto>>> GetAll(
        int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "",
        [FromQuery] ShippingStatus? status = null, bool problemsOnly = false, [FromQuery] Guid? salesId = null)
    {
        if (string.IsNullOrEmpty(salesBy))
        {
            salesBy = "ShippedAt Descending";
        }

        var response = await mediator.Send(new ShippingListQuery(
            pageNumber, pageSize, searchString, salesBy, status, problemsOnly, salesId));
        return response.ToActionResult();
    }

    // GET: api/v1/<ShippingsController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShippingDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new ShippingDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // GET: api/v1/<ShippingsController>/5/label
    [HttpGet("{id:guid}/label")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLabel(Guid id)
    {
        var response = await mediator.Send(new ShippingLabelQuery { Id = id });

        // The one action returning a file — unwrap the Result manually.
        if (!response.Succeeded || response.Data == null)
        {
            return response.ToActionResult();
        }

        return File(response.Data.Data, response.Data.ContentType, response.Data.FileName);
    }

    // POST: api/v1/<ShippingsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(ShippingCreateCommand shippingCreateCommand)
    {
        var response = await mediator.Send(shippingCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<ShippingsController>/5
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(Guid id, ShippingUpdateCommand shippingUpdateCommand)
    {
        // Validate ID consistency between URL and body if ID is provided in body and differs
        if (shippingUpdateCommand.Id != Guid.Empty && shippingUpdateCommand.Id != id)
        {
            var errorResponse = ProblemDetailsResult.BadRequest(
                "Invalid Request",
                $"ID in URL ({id}) must match ID in request body ({shippingUpdateCommand.Id})",
                "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                $"/api/v1/shippings/{id}"
            );
            return errorResponse.ToActionResult();
        }

        shippingUpdateCommand.Id = id;
        var response = await mediator.Send(shippingUpdateCommand);
        return response.ToActionResult();
    }

    // POST: api/v1/<ShippingsController>/5/cancel
    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Cancel(Guid id)
    {
        var command = new ShippingCancelCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // POST: api/v1/<ShippingsController>/5/label/retry
    [HttpPost("{id:guid}/label/retry")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RetryLabel(Guid id)
    {
        var command = new ShippingLabelRetryCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<ShippingsController>/5
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new ShippingDeleteCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
