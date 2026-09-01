using asERP.Application.Mediator;
using asERP.Domain.Dtos.Invoice;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Queries.InvoiceDetail;

/// <summary>
/// Query for retrieving detailed information about a specific invoice.
/// Implements IRequest to work with the custom mediator, returning invoice details wrapped in a Result.
/// </summary>
public class InvoiceDetailQuery : IRequest<Result<InvoiceDetailDto>>
{
    /// <summary>
    /// The unique identifier of the invoice to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
