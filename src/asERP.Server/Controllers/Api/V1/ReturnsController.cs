using asERP.Application.Features.Returns.Commands.ReturnCancel;
using asERP.Application.Features.Returns.Commands.ReturnComplete;
using asERP.Application.Features.Returns.Commands.ReturnCreate;
using asERP.Application.Features.Returns.Commands.ReturnLabelRetry;
using asERP.Application.Features.Returns.Commands.ReturnReceive;
using asERP.Application.Features.Returns.Queries.ReturnDetail;
using asERP.Application.Features.Returns.Queries.ReturnLabel;
using asERP.Application.Features.Returns.Queries.ReturnList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
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
public class ReturnsController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<ReturnsController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<ReturnShipmentListItemDto>>> GetAll(
        int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "",
        [FromQuery] ReturnShipmentStatus? status = null, [FromQuery] Guid? salesId = null)
    {
        var response = await mediator.Send(new ReturnListQuery(
            pageNumber, pageSize, searchString, salesBy, status, salesId));
        return response.ToActionResult();
    }

    // GET: api/v1/<ReturnsController>/5
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReturnShipmentDetailDto>> GetDetails(Guid id)
    {
        var response = await mediator.Send(new ReturnDetailQuery { Id = id });
        return response.ToActionResult();
    }

    // GET: api/v1/<ReturnsController>/5/label
    [HttpGet("{id:guid}/label")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLabel(Guid id)
    {
        var response = await mediator.Send(new ReturnLabelQuery { Id = id });

        // The one action returning a file — unwrap the Result manually.
        if (!response.Succeeded || response.Data == null)
        {
            return response.ToActionResult();
        }

        return File(response.Data.Data, response.Data.ContentType, response.Data.FileName);
    }

    // POST: api/v1/<ReturnsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(ReturnCreateCommand returnCreateCommand)
    {
        var response = await mediator.Send(returnCreateCommand);
        return response.ToActionResult();
    }

    // POST: api/v1/<ReturnsController>/5/receive
    [HttpPost("{id:guid}/receive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Receive(Guid id, ReturnReceiveInputDto input)
    {
        var command = new ReturnReceiveCommand
        {
            Id = id,
            Items = input.Items,
            RefundAmount = input.RefundAmount,
            Note = input.Note
        };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // POST: api/v1/<ReturnsController>/5/cancel
    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Cancel(Guid id)
    {
        var command = new ReturnCancelCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // POST: api/v1/<ReturnsController>/5/complete?reject=true
    [HttpPost("{id:guid}/complete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Complete(Guid id, [FromQuery] bool reject = false)
    {
        var command = new ReturnCompleteCommand { Id = id, Reject = reject };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }

    // POST: api/v1/<ReturnsController>/5/label/retry
    [HttpPost("{id:guid}/label/retry")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RetryLabel(Guid id)
    {
        var command = new ReturnLabelRetryCommand { Id = id };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
