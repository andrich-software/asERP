#if __DESKTOP__
using System.Diagnostics;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// Desktop (Skia) label actions: native save dialog everywhere; direct printing via
/// System.Drawing.Printing on Windows (PDF pages rasterized with PDFtoImage/PDFium at
/// 300 dpi; GIF/PNG labels — e.g. UPS — go through the same image print path directly).
/// Non-Windows desktops fall back to opening the label with the system default app.
/// </summary>
public partial class LabelService
{
    public LabelCapabilities Capabilities =>
        LabelCapabilities.Save
        | (OperatingSystem.IsWindows()
            ? LabelCapabilities.Print | LabelCapabilities.PickPrinter
            : LabelCapabilities.None);

    public Task<IReadOnlyList<string>> GetPrinterNamesAsync()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Task.FromResult<IReadOnlyList<string>>(Array.Empty<string>());
        }

        return Task.FromResult(WindowsPrinting.GetInstalledPrinters());
    }

    public async Task<bool> SaveAsync(LabelFile label)
    {
        var extension = LabelContentTypes.GetExtension(label.ContentType);
        var picker = new FileSavePicker
        {
            SuggestedFileName = Path.GetFileNameWithoutExtension(label.FileName),
        };
        picker.FileTypeChoices.Add(extension.TrimStart('.').ToUpperInvariant(), new List<string> { extension });

        var file = await picker.PickSaveFileAsync();
        if (file is null)
        {
            return false;
        }

        await FileIO.WriteBytesAsync(file, label.Bytes);
        return true;
    }

    public async Task PrintAsync(LabelFile label, string? printerName)
    {
        if (!OperatingSystem.IsWindows())
        {
            // No direct spooler access on macOS/Linux Skia — the system viewer prints.
            await OpenWithSystemDefaultAsync(label);
            return;
        }

        // Guard repeated inside the lambda — CA1416 does not follow the guard across Task.Run.
        await Task.Run(() =>
        {
            if (OperatingSystem.IsWindows())
            {
                WindowsPrinting.Print(label, printerName);
            }
        });
    }

    public async Task OpenWithSystemDefaultAsync(LabelFile label)
    {
        var path = Path.Combine(Path.GetTempPath(), label.FileName);
        await File.WriteAllBytesAsync(path, label.Bytes);
        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
    }
}

/// <summary>
/// Windows-only printing helpers, isolated so every System.Drawing call sits behind an
/// <see cref="OperatingSystem.IsWindows"/> guard (System.Drawing.Common throws on other OSes).
/// </summary>
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
internal static class WindowsPrinting
{
    public static IReadOnlyList<string> GetInstalledPrinters()
    {
        var printers = new List<string>();
        foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
        {
            printers.Add(printer);
        }
        return printers;
    }

    public static void Print(LabelFile label, string? printerName)
    {
        var pages = RenderPages(label);
        try
        {
            using var document = new System.Drawing.Printing.PrintDocument();
            if (!string.IsNullOrWhiteSpace(printerName))
            {
                document.PrinterSettings.PrinterName = printerName;
            }

            var pageIndex = 0;
            document.PrintPage += (_, e) =>
            {
                var image = pages[pageIndex];
                var bounds = e.PageBounds;

                // Scale preserving aspect ratio, centered on the page.
                var scale = Math.Min((float)bounds.Width / image.Width, (float)bounds.Height / image.Height);
                var width = image.Width * scale;
                var height = image.Height * scale;
                var x = bounds.X + (bounds.Width - width) / 2f;
                var y = bounds.Y + (bounds.Height - height) / 2f;

                e.Graphics!.DrawImage(image, x, y, width, height);

                pageIndex++;
                e.HasMorePages = pageIndex < pages.Count;
            };

            document.Print();
        }
        finally
        {
            foreach (var page in pages)
            {
                page.Dispose();
            }
        }
    }

    /// <summary>PDF labels are rasterized per page at 300 dpi; image labels print directly.</summary>
    private static List<System.Drawing.Image> RenderPages(LabelFile label)
    {
        var pages = new List<System.Drawing.Image>();

        if (LabelContentTypes.IsPdf(label.ContentType))
        {
#pragma warning disable CA1416 // PDFtoImage supports Windows; this type is windows-only already.
            foreach (var bitmap in PDFtoImage.Conversion.ToImages(label.Bytes, options: new PDFtoImage.RenderOptions(Dpi: 300)))
            {
                using (bitmap)
                {
                    using var encoded = bitmap.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100);
                    pages.Add(System.Drawing.Image.FromStream(new MemoryStream(encoded.ToArray())));
                }
            }
#pragma warning restore CA1416
        }
        else
        {
            pages.Add(System.Drawing.Image.FromStream(new MemoryStream(label.Bytes)));
        }

        return pages;
    }
}
#endif
