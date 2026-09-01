using asERP.Application.Features.Invoice.Commands.InvoiceUpdate;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Invoice;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Commands.InvoiceCreate;

/// <summary>
/// Command for creating a new invoice in the system.
/// Inherits from CreateInvoiceDto to get all invoice properties and implements IRequest
/// to work with the custom mediator, returning the ID of the newly created invoice wrapped in a Result.
/// </summary>
public class InvoiceCreateCommand : InvoiceInputDto, IRequest<Result<Guid>>
{
}
