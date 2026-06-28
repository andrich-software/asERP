using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Invoice.Queries.InvoicePdf;

public record InvoicePdfQuery : IRequest<Result<byte[]>>
{
    public Guid Id { get; set; }
}