using asToolkit.Application.Features.Invoice.Commands.InvoiceUpdate;
using asToolkit.Domain.Dtos.Invoice;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Invoice.Commands.InvoiceCreate;

/// <summary>
/// Command for creating a new invoice in the system.
/// Inherits from CreateInvoiceDto to get all invoice properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created invoice wrapped in a Result.
/// </summary>
public class InvoiceCreateCommand : InvoiceInputDto, IRequest<Result<Guid>>
{
}
