using System;
using System.Globalization;
using System.IO;
using System.Linq;
using asERP.Domain.Dtos.Shipping;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;

namespace asERP.Infrastructure.PDF;

/// <summary>
/// Packing-slip and pick-list rendering — same MigraDoc infrastructure and visual style
/// as the invoice PDF in <see cref="PdfService"/>.
/// </summary>
public partial class PdfService
{
    public byte[] GeneratePackingSlip(PackingSlipData data)
    {
        ArgumentNullException.ThrowIfNull(data);

        var document = CreateShippingDocumentShell();
        var section = document.LastSection;

        CreatePackingSlipHeader(section, data);
        CreateDeliveryAddress(section, data);
        CreatePackingSlipItemsTable(section, data);
        CreateFooter(section, data.Company);

        return RenderDocument(document);
    }

    public byte[] GeneratePickList(PickListData data)
    {
        ArgumentNullException.ThrowIfNull(data);

        var document = CreateShippingDocumentShell();
        var section = document.LastSection;

        CreatePickListHeader(section, data);
        CreatePickListItemsTable(section, data);
        CreateFooter(section, data.Company);

        return RenderDocument(document);
    }

    private static Document CreateShippingDocumentShell()
    {
        var document = new Document();

        var style = document.Styles["Normal"];
        style!.Font.Name = "Helvetica";
        style.Font.Size = 10;

        var section = document.AddSection();
        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.TopMargin = Unit.FromCentimeter(2);
        section.PageSetup.LeftMargin = Unit.FromCentimeter(2);
        section.PageSetup.RightMargin = Unit.FromCentimeter(2);
        section.PageSetup.BottomMargin = Unit.FromCentimeter(2);

        return document;
    }

    private byte[] RenderDocument(Document document)
    {
        if (GlobalFontSettings.FontResolver == null)
        {
            GlobalFontSettings.FontResolver = new StandardFontResolver();
        }

        var pdfRenderer = new PdfDocumentRenderer
        {
            Document = document,
            PdfDocument = new PdfDocument()
        };

        pdfRenderer.RenderDocument();

        using var stream = new MemoryStream();
        pdfRenderer.PdfDocument.Save(stream, false);
        return stream.ToArray();
    }

    private void CreatePackingSlipHeader(Section section, PackingSlipData data)
    {
        var table = section.AddTable();
        table.Borders = new Borders();
        table.Borders.Visible = false;

        table.AddColumn(Unit.FromCentimeter(10));
        table.AddColumn(Unit.FromCentimeter(7));

        var row = table.AddRow();

        // Left column: logo and company info (same as invoice)
        var company = data.Company;
        var cell = row.Cells[0];
        var paragraph = cell.AddParagraph();

        if (!string.IsNullOrEmpty(company.LogoPath) && File.Exists(company.LogoPath))
        {
            var logo = paragraph.AddImage(company.LogoPath);
            logo.Height = Unit.FromCentimeter(2);
        }
        else
        {
            paragraph.AddFormattedText(company.Name, TextFormat.Bold);
        }

        cell.AddParagraph(company.Street);
        if (!string.IsNullOrWhiteSpace(company.Street2))
        {
            cell.AddParagraph(company.Street2);
        }
        cell.AddParagraph(company.ZipCity);
        cell.AddParagraph(company.Country);
        cell.AddParagraph($"Tel: {company.Phone}");
        cell.AddParagraph($"E-Mail: {company.Email}");
        cell.AddParagraph($"Web: {company.Website}");

        // Right column: shipment info
        cell = row.Cells[1];
        paragraph = cell.AddParagraph("PACKLISTE");
        paragraph.Format.Alignment = ParagraphAlignment.Right;
        paragraph.Format.Font.Bold = true;
        paragraph.Format.Font.Size = 16;

        paragraph = cell.AddParagraph($"Bestellnummer: {data.SalesNumber}");
        paragraph.Format.Alignment = ParagraphAlignment.Right;

        paragraph = cell.AddParagraph($"Bestelldatum: {data.SalesDate:dd.MM.yyyy}");
        paragraph.Format.Alignment = ParagraphAlignment.Right;

        if (!string.IsNullOrEmpty(data.TrackingNumber))
        {
            paragraph = cell.AddParagraph($"Sendungsnummer: {data.TrackingNumber}");
            paragraph.Format.Alignment = ParagraphAlignment.Right;
        }

        paragraph = cell.AddParagraph($"Paket {data.PackageIndex} von {data.PackageCount}");
        paragraph.Format.Alignment = ParagraphAlignment.Right;
        paragraph.Format.Font.Bold = true;

        section.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(0.5);
    }

    private static void CreateDeliveryAddress(Section section, PackingSlipData data)
    {
        var paragraph = section.AddParagraph("Lieferadresse:");
        paragraph.Format.Font.Bold = true;

        var recipientName = !string.IsNullOrEmpty(data.DeliveryCompanyName)
            ? data.DeliveryCompanyName
            : $"{data.DeliveryFirstName} {data.DeliveryLastName}".Trim();

        section.AddParagraph(recipientName);
        section.AddParagraph(data.DeliveryStreet);
        section.AddParagraph($"{data.DeliveryZip} {data.DeliveryCity}".Trim());
        section.AddParagraph(data.DeliveryCountry);

        section.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(0.5);
    }

    private static void CreatePackingSlipItemsTable(Section section, PackingSlipData data)
    {
        if (data.Items.Count == 0)
        {
            var hint = section.AddParagraph("Dieser Sendung sind keine Positionen zugeordnet.");
            hint.Format.SpaceAfter = Unit.FromCentimeter(0.5);
            return;
        }

        var table = section.AddTable();
        table.Borders = new Borders();
        table.Borders.Width = 0.5;

        table.AddColumn(Unit.FromCentimeter(2));  // Menge
        table.AddColumn(data.ShowPrices ? Unit.FromCentimeter(11) : Unit.FromCentimeter(15)); // Artikel
        if (data.ShowPrices)
        {
            table.AddColumn(Unit.FromCentimeter(2)); // Einzelpreis
            table.AddColumn(Unit.FromCentimeter(2)); // Gesamt
        }

        var headerRow = table.AddRow();
        headerRow.HeadingFormat = true;
        headerRow.Format.Font.Bold = true;
        headerRow.Shading.Color = new Color(230, 230, 230);

        headerRow.Cells[0].AddParagraph("Menge");
        headerRow.Cells[1].AddParagraph("Artikel");
        if (data.ShowPrices)
        {
            headerRow.Cells[2].AddParagraph("Einzelpreis");
            headerRow.Cells[3].AddParagraph("Gesamt");
        }

        foreach (var item in data.Items)
        {
            var row = table.AddRow();

            row.Cells[0].AddParagraph(item.Quantity.ToString("0.##", CultureInfo.InvariantCulture));

            var cell = row.Cells[1];
            var paragraph = cell.AddParagraph(string.IsNullOrWhiteSpace(item.Name) ? "Artikel" : item.Name);
            paragraph.Format.Font.Bold = true;

            if (!string.IsNullOrWhiteSpace(item.Sku))
            {
                cell.AddParagraph($"Art.-Nr.: {item.Sku}");
            }

            if (!string.IsNullOrWhiteSpace(item.Ean))
            {
                cell.AddParagraph($"EAN: {item.Ean}");
            }

            foreach (var serialNumber in item.SerialNumbers)
            {
                cell.AddParagraph($"S/N: {serialNumber}");
            }

            if (data.ShowPrices)
            {
                row.Cells[2].AddParagraph($"{item.Price:0.00} €");
                row.Cells[3].AddParagraph($"{item.Price * (decimal)item.Quantity:0.00} €");
            }
        }

        section.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(0.5);
    }

    private void CreatePickListHeader(Section section, PickListData data)
    {
        var table = section.AddTable();
        table.Borders = new Borders();
        table.Borders.Visible = false;

        table.AddColumn(Unit.FromCentimeter(10));
        table.AddColumn(Unit.FromCentimeter(7));

        var row = table.AddRow();

        var company = data.Company;
        var cell = row.Cells[0];
        var paragraph = cell.AddParagraph();

        if (!string.IsNullOrEmpty(company.LogoPath) && File.Exists(company.LogoPath))
        {
            var logo = paragraph.AddImage(company.LogoPath);
            logo.Height = Unit.FromCentimeter(2);
        }
        else
        {
            paragraph.AddFormattedText(company.Name, TextFormat.Bold);
        }

        cell = row.Cells[1];
        paragraph = cell.AddParagraph("PICKLISTE");
        paragraph.Format.Alignment = ParagraphAlignment.Right;
        paragraph.Format.Font.Bold = true;
        paragraph.Format.Font.Size = 16;

        var salesNumbers = string.Join(", ", data.SalesNumbers);
        paragraph = cell.AddParagraph(data.SalesNumbers.Count > 1
            ? $"Bestellnummern: {salesNumbers}"
            : $"Bestellnummer: {salesNumbers}");
        paragraph.Format.Alignment = ParagraphAlignment.Right;

        section.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(0.5);
    }

    private static void CreatePickListItemsTable(Section section, PickListData data)
    {
        if (data.Items.Count == 0)
        {
            var hint = section.AddParagraph("Keine Positionen zu picken.");
            hint.Format.SpaceAfter = Unit.FromCentimeter(0.5);
            return;
        }

        var showSalesNumber = data.SalesNumbers.Count > 1;

        var table = section.AddTable();
        table.Borders = new Borders();
        table.Borders.Width = 0.5;

        table.AddColumn(Unit.FromCentimeter(2.5)); // Lagerplatz
        table.AddColumn(Unit.FromCentimeter(3));   // Lager
        table.AddColumn(Unit.FromCentimeter(2));   // Menge
        table.AddColumn(showSalesNumber ? Unit.FromCentimeter(5) : Unit.FromCentimeter(6.5)); // Artikel
        table.AddColumn(Unit.FromCentimeter(3));   // Art.-Nr.
        if (showSalesNumber)
        {
            table.AddColumn(Unit.FromCentimeter(1.5)); // Bestellnr.
        }

        var headerRow = table.AddRow();
        headerRow.HeadingFormat = true;
        headerRow.Format.Font.Bold = true;
        headerRow.Shading.Color = new Color(230, 230, 230);

        headerRow.Cells[0].AddParagraph("Lagerplatz");
        headerRow.Cells[1].AddParagraph("Lager");
        headerRow.Cells[2].AddParagraph("Menge");
        headerRow.Cells[3].AddParagraph("Artikel");
        headerRow.Cells[4].AddParagraph("Art.-Nr.");
        if (showSalesNumber)
        {
            headerRow.Cells[5].AddParagraph("Bestellnr.");
        }

        foreach (var item in data.Items)
        {
            var row = table.AddRow();

            row.Cells[0].AddParagraph(item.StorageLocation.HasValue
                ? item.StorageLocation.Value.ToString("0.##", CultureInfo.InvariantCulture)
                : "–");
            row.Cells[1].AddParagraph(string.IsNullOrEmpty(item.WarehouseName) ? "–" : item.WarehouseName);
            row.Cells[2].AddParagraph(item.Quantity.ToString("0.##", CultureInfo.InvariantCulture));
            row.Cells[3].AddParagraph(string.IsNullOrWhiteSpace(item.Name) ? "Artikel" : item.Name);
            row.Cells[4].AddParagraph(string.IsNullOrWhiteSpace(item.Sku) ? "–" : item.Sku);
            if (showSalesNumber)
            {
                row.Cells[5].AddParagraph(item.SalesNumber.ToString(CultureInfo.InvariantCulture));
            }
        }

        section.AddParagraph().Format.SpaceAfter = Unit.FromCentimeter(0.5);
    }
}
