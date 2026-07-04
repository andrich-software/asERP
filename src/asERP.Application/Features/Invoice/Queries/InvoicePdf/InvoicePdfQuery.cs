using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Queries.InvoicePdf;

public record InvoicePdfQuery : IRequest<Result<byte[]>>
{
    public Guid Id { get; set; }
}