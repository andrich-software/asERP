using asToolkit.Client.Core.Models;
using asToolkit.Domain.Dtos.Invoice;

namespace asToolkit.Client.Features.Invoices.Services;

/// <summary>
/// Service interface for invoice-related API operations.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Gets a paginated list of invoices with full pagination metadata.
    /// </summary>
    Task<PaginatedResponse<InvoiceListDto>> GetInvoicesAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single invoice by ID.
    /// </summary>
    Task<InvoiceDetailDto?> GetInvoiceAsync(Guid id, CancellationToken ct = default);
}
