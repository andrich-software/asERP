using asERP.Application.Features.Invoice.Commands.InvoiceCreate;
using asERP.Application.Features.Invoice.Commands.InvoiceDelete;
using asERP.Application.Features.Invoice.Commands.InvoiceUpdate;
using asERP.Application.Features.Invoice.Queries.InvoiceDetail;
using asERP.Application.Features.Invoice.Queries.InvoiceList;
using asERP.Application.Features.Invoice.Queries.InvoicePdf;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Invoice;
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
public class InvoicesController(IMediator mediator) : ControllerBase
{
    // GET: api/v1/<InvoiceController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedResult<InvoiceListDto>>> GetAll(int pageNumber = 0, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        // Validate pagination parameters
        if (pageNumber < 0)
        {
            var errorResult = new Result<PaginatedResult<InvoiceListDto>>();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "PageNumber muss größer oder gleich 0 sein.");
            return BadRequest(errorResult);
        }

        if (pageSize < 1)
        {
            var errorResult = new Result<PaginatedResult<InvoiceListDto>>();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "PageSize muss größer als 0 sein.");
            return BadRequest(errorResult);
        }

        if (string.IsNullOrEmpty(sortBy))
        {
            sortBy = "InvoiceDate Descending";
        }

        var invoices = await mediator.Send(new InvoiceListQuery(pageNumber, pageSize, searchString, sortBy));
        return Ok(invoices);
    }

    // GET: api/v1/<InvoiceController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InvoiceDetailDto>> GetDetails(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            var errorResult = new Result<InvoiceDetailDto>();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Ungültige ID-Format. Eine gültige GUID ist erfsaleslich.");
            return BadRequest(errorResult);
        }

        var response = await mediator.Send(new InvoiceDetailQuery { Id = guidId });
        return response.ToActionResult();
    }

    // GET: api/v1/<InvoiceController>/5/pdf
    [HttpGet("{id}/pdf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPdf(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            var errorResult = new Result<byte[]>();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Ungültige ID-Format. Eine gültige GUID ist erfsaleslich.");
            return BadRequest(errorResult);
        }

        var response = await mediator.Send(new InvoicePdfQuery { Id = guidId });

        return response.ToActionResult();
    }

    // POST: api/v1/<InvoiceController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Create(InvoiceCreateCommand invoiceCreateCommand)
    {
        var response = await mediator.Send(invoiceCreateCommand);
        return response.ToActionResult();
    }

    // PUT: api/v1/<InvoiceController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(string id, InvoiceUpdateCommand invoiceUpdateCommand)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            var errorResult = new Result();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Ungültige ID-Format. Eine gültige GUID ist erfsaleslich.");
            return BadRequest(errorResult);
        }

        if (invoiceUpdateCommand.Id != Guid.Empty && invoiceUpdateCommand.Id != guidId)
        {
            var mismatchResult = Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Die in der Anfrage angegebene ID stimmt nicht mit der URL überein.");
            return BadRequest(mismatchResult);
        }

        invoiceUpdateCommand.Id = guidId;
        var response = await mediator.Send(invoiceUpdateCommand);
        return response.ToActionResult();
    }

    // DELETE: api/v1/<InvoiceController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guidId))
        {
            var errorResult = new Result();
            errorResult.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Ungültige ID-Format. Eine gültige GUID ist erfsaleslich.");
            return BadRequest(errorResult);
        }

        var command = new InvoiceDeleteCommand { Id = guidId };
        var response = await mediator.Send(command);
        return response.ToActionResult();
    }
}
