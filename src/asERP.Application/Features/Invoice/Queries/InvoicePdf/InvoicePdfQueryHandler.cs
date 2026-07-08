using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;
using Microsoft.Extensions.Logging;

namespace asERP.Application.Features.Invoice.Queries.InvoicePdf;

public class InvoicePdfQueryHandler : IRequestHandler<InvoicePdfQuery, Result<byte[]>>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IPdfService _pdfService;
    private readonly ILogger<InvoicePdfQueryHandler> _logger;

    public InvoicePdfQueryHandler(
        IInvoiceRepository invoiceRepository,
        ITenantRepository tenantRepository,
        IPdfService pdfService,
        ILogger<InvoicePdfQueryHandler> logger)
    {
        _invoiceRepository = invoiceRepository;
        _tenantRepository = tenantRepository;
        _pdfService = pdfService;
        _logger = logger;
    }

    public async Task<Result<byte[]>> Handle(InvoicePdfQuery request, CancellationToken cancellationToken)
    {
        try
        {
            // Rechnung mit allen Details abrufen
            var invoice = await _invoiceRepository.GetInvoiceWithDetailsAsync(request.Id);
            if (invoice == null)
            {
                return await Result<byte[]>.FailAsync(ResultStatusCode.NotFound, "Rechnung nicht gefunden");
            }

            // Firmendaten (Absender) stammen aus dem Mandanten, nicht mehr aus globalen Einstellungen.
            if (!invoice.TenantId.HasValue)
            {
                return await Result<byte[]>.FailAsync(ResultStatusCode.InternalServerError, "Rechnung ist keinem Mandanten zugeordnet");
            }

            var tenant = await _tenantRepository.GetByIdAsync(invoice.TenantId.Value, asNoTracking: true);
            if (tenant == null)
            {
                return await Result<byte[]>.FailAsync(ResultStatusCode.NotFound, "Mandant der Rechnung nicht gefunden");
            }

            // PDF generieren
            var pdfBytes = _pdfService.GenerateInvoice(invoice, tenant.ToCompanySenderInfo());
            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                return await Result<byte[]>.FailAsync(ResultStatusCode.InternalServerError, "PDF konnte nicht generiert werden");
            }

            return await Result<byte[]>.SuccessAsync(pdfBytes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fehler beim Generieren der Rechnungs-PDF für ID {InvoiceId}", request.Id);
            return await Result<byte[]>.FailAsync(ResultStatusCode.InternalServerError, "Fehler beim Generieren der PDF.");
        }
    }

}
