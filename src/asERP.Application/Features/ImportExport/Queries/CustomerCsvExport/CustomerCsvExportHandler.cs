using System.Globalization;
using System.Text;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Wrapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.ImportExport.Queries.CustomerCsvExport;

/// <summary>
/// Handler for processing customer CSV export queries.
/// Implements IRequestHandler from MediatR to handle CustomerCsvExportQuery requests
/// and return CSV export data wrapped in a Result.
/// </summary>
public class CustomerCsvExportHandler : IRequestHandler<CustomerCsvExportQuery, Result<CustomerCsvExportResult>>
{
    private readonly IAppLogger<CustomerCsvExportHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerCsvExportHandler(
        IAppLogger<CustomerCsvExportHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<CustomerCsvExportResult>> Handle(CustomerCsvExportQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting CSV export of customers with search: '{SearchString}'", request.SearchString);

        var result = new Result<CustomerCsvExportResult>();
        var exportResult = new CustomerCsvExportResult();

        try
        {
            // Create filter specification
            var customerFilterSpec = new CustomerFilterSpecification(request.SearchString);

            // Get customers from database
            var query = _customerRepository.Entities
                .Specify(customerFilterSpec)
                .Where(c => !request.ActiveCustomersOnly || c.CustomerStatus == Domain.Enums.CustomerStatus.Active);

            // Eager-load addresses (and their country) only when the export includes them, so the
            // per-address rows have real data instead of always falling into the "no address" branch.
            if (request.IncludeAddresses)
            {
                query = query.Include($"{nameof(Domain.Entities.Customer.CustomerAddresses)}.{nameof(Domain.Entities.CustomerAddress.Country)}");
            }

            var customers = await query
                .OrderBy(c => c.Lastname)
                .ThenBy(c => c.Firstname)
                .ToListAsync(cancellationToken);

            _logger.LogInformation("Retrieved {Count} customers for CSV export", customers.Count);

            // Generate CSV content
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream, Encoding.UTF8);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                // Prefix cells starting with a formula trigger (= + - @ tab) with an apostrophe so
                // spreadsheet apps treat them as text (CSV formula injection). Quoting is left to
                // CsvHelper's defaults, which also handle CR/LF that the custom predicate missed.
                InjectionOptions = InjectionOptions.Escape
            };

            using var csv = new CsvWriter(writer, config);

            // Write header
            csv.WriteField("Firstname");
            csv.WriteField("Lastname");
            csv.WriteField("CompanyName");
            csv.WriteField("Email");
            csv.WriteField("Phone");
            csv.WriteField("Website");
            csv.WriteField("VatNumber");
            csv.WriteField("Note");
            csv.WriteField("CustomerStatus");
            csv.WriteField("DateEnrollment");

            if (request.IncludeAddresses)
            {
                csv.WriteField("AddressFirstname");
                csv.WriteField("AddressLastname");
                csv.WriteField("AddressCompanyName");
                csv.WriteField("Street");
                csv.WriteField("HouseNr");
                csv.WriteField("Zip");
                csv.WriteField("City");
                csv.WriteField("Country");
                csv.WriteField("DefaultDeliveryAddress");
                csv.WriteField("DefaultInvoiceAddress");
            }

            await csv.NextRecordAsync();

            // Write customer data
            foreach (var customer in customers)
            {
                if (request.IncludeAddresses && customer.CustomerAddresses != null && customer.CustomerAddresses.Any())
                {
                    // Export one row per address
                    foreach (var address in customer.CustomerAddresses)
                    {
                        WriteCustomerRow(csv, customer, address, request.IncludeAddresses);
                        await csv.NextRecordAsync();
                    }
                }
                else
                {
                    // Export one row per customer; when addresses are requested but the customer has
                    // none, the address columns are still written (empty) so the row width matches the header.
                    WriteCustomerRow(csv, customer, null, request.IncludeAddresses);
                    await csv.NextRecordAsync();
                }
            }

            await writer.FlushAsync();
            exportResult.CsvData = memoryStream.ToArray();
            exportResult.CustomerCount = customers.Count;
            exportResult.FileName = $"customers_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = exportResult;

            _logger.LogInformation("CSV export completed successfully. Exported {Count} customers, file size: {Size} bytes",
                customers.Count, exportResult.CsvData.Length);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred during CSV export.",
                "Error during customer CSV export");
        }

        return result;
    }

    private static void WriteCustomerRow(CsvWriter csv, Domain.Entities.Customer customer, Domain.Entities.CustomerAddress? address, bool includeAddresses)
    {
        csv.WriteField(customer.Firstname);
        csv.WriteField(customer.Lastname);
        csv.WriteField(customer.CompanyName);
        csv.WriteField(customer.Email);
        csv.WriteField(customer.Phone);
        csv.WriteField(customer.Website);
        csv.WriteField(customer.VatNumber);
        csv.WriteField(customer.Note);
        csv.WriteField(customer.CustomerStatus.ToString());
        csv.WriteField(customer.DateEnrollment.ToString("yyyy-MM-dd HH:mm:ss zzz"));

        if (!includeAddresses)
        {
            return;
        }

        // Always emit the 10 address columns when addresses are included, so every data row is
        // exactly as wide as the header even for customers without an address.
        csv.WriteField(address?.Firstname ?? string.Empty);
        csv.WriteField(address?.Lastname ?? string.Empty);
        csv.WriteField(address?.CompanyName ?? string.Empty);
        csv.WriteField(address?.Street ?? string.Empty);
        csv.WriteField(address?.HouseNr ?? string.Empty);
        csv.WriteField(address?.Zip ?? string.Empty);
        csv.WriteField(address?.City ?? string.Empty);
        csv.WriteField(address?.Country?.Name ?? string.Empty);
        csv.WriteField((address?.DefaultDeliveryAddress ?? false).ToString());
        csv.WriteField((address?.DefaultInvoiceAddress ?? false).ToString());
    }
}
