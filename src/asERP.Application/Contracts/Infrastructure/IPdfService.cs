using asERP.Domain.Dtos.Company;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Infrastructure;

/// <summary>
/// Interface for PDF document generation service
/// </summary>
public interface IPdfService
{
    /// <summary>
    /// Generates a PDF invoice from the given Invoice entity
    /// </summary>
    /// <param name="invoice">The invoice entity to generate PDF for</param>
    /// <param name="company">The tenant's company/sender block printed on the invoice</param>
    /// <param name="outputPath">Optional path to save the PDF file. If null, returns the PDF as a byte array</param>
    /// <returns>Byte array containing the PDF if outputPath is null, otherwise returns null after saving to file</returns>
    byte[]? GenerateInvoice(Invoice invoice, CompanySenderInfo company, string? outputPath = null);

    /// <summary>Generates the packing-slip PDF for a single shipment.</summary>
    byte[] GeneratePackingSlip(PackingSlipData data);

    /// <summary>Generates the pick-list PDF (location-sorted, one or more orders).</summary>
    byte[] GeneratePickList(PickListData data);
}
