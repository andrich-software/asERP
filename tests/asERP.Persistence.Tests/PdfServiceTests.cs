using asERP.Domain.Dtos.Company;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Infrastructure.PDF;

namespace asERP.Persistence.Tests;

public class PdfServiceTests
{
    private static CompanySenderInfo SampleCompany() => new()
    {
        Name = "Test Company",
        Street = "Test Street 1",
        ZipCity = "12345 Test City",
        Country = "Test Country",
        Phone = "+49 123 456",
        Email = "info@test.com",
        Website = "https://test.com",
        TaxId = "TAX-123",
        VatId = "VAT-456",
        BankName = "Test Bank",
        Iban = "DE00 0000 0000 0000",
        Bic = "TESTDEFF"
    };

    [Fact]
    public void GenerateInvoice_WithOutputPath_ShouldReturnBytesAndPersistFile()
    {
        // Arrange
        var pdfService = new PdfService();

        var invoice = new Invoice
        {
            TenantId = Guid.NewGuid(),
            InvoiceNumber = "INV-1000",
            InvoiceDate = DateTime.UtcNow,
            CustomerId = 42,
            Subtotal = 100m,
            ShippingCost = 5m,
            TotalTax = 19m,
            Total = 124m,
            PaymentStatus = PaymentStatus.Invoiced,
            InvoiceStatus = InvoiceStatus.Created,
            PaymentMethod = "Bank Transfer",
            PaymentTransactionId = "TXN-001",
            Notes = "Test invoice",
            InvoiceAddressFirstName = "John",
            InvoiceAddressLastName = "Doe",
            InvoiceAddressStreet = "Main Street 1",
            InvoiceAddressCity = "Test City",
            InvoiceAddressZip = "12345",
            InvoiceAddressCountry = "Test Country",
            DeliveryAddressFirstName = "John",
            DeliveryAddressLastName = "Doe",
            DeliveryAddressStreet = "Main Street 1",
            DeliveryAddressCity = "Test City",
            DeliveryAddressZip = "12345",
            DeliveryAddressCountry = "Test Country",
            InvoiceItems = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    Name = "Sample item",
                    Quantity = 2,
                    Unit = "pcs",
                    UnitPrice = 50m,
                    TotalPrice = 100m,
                    TaxRate = 19,
                    TaxAmount = 19m
                }
            }
        };

        var tempDirectory = Path.Combine(Path.GetTempPath(), "aserp-pdf-tests", Guid.NewGuid().ToString("N"));
        var outputPath = Path.Combine(tempDirectory, "invoice.pdf");

        try
        {
            // Act
            var pdfBytes = pdfService.GenerateInvoice(invoice, SampleCompany(), outputPath);

            // Assert
            Assert.NotNull(pdfBytes);
            Assert.True(pdfBytes!.Length > 0);
            Assert.True(File.Exists(outputPath));

            var persistedBytes = File.ReadAllBytes(outputPath);
            Assert.Equal(pdfBytes.Length, persistedBytes.Length);
        }
        finally
        {
            if (Directory.Exists(tempDirectory))
            {
                Directory.Delete(tempDirectory, true);
            }
        }
    }
}
