#if __WASM__
using System.Runtime.InteropServices.JavaScript;

namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// WASM label actions via Platforms/WebAssembly/WasmScripts/LabelInterop.js:
/// download = Blob + anchor click; print = hidden iframe + contentWindow.print()
/// (the browser's print dialog owns printer selection, so no printer enumeration here).
/// </summary>
public partial class LabelService
{
    public LabelCapabilities Capabilities => LabelCapabilities.Download | LabelCapabilities.Print;

    public Task<IReadOnlyList<string>> GetPrinterNamesAsync() =>
        Task.FromResult<IReadOnlyList<string>>(Array.Empty<string>());

    public Task<bool> SaveAsync(LabelFile label)
    {
        LabelInterop.Download(label.FileName, label.ContentType, Convert.ToBase64String(label.Bytes));
        return Task.FromResult(true);
    }

    public async Task<bool> SaveAllAsync(IReadOnlyList<LabelFile> labels)
    {
        foreach (var label in labels)
        {
            await SaveAsync(label);
            // Small gap between anchor-click downloads so browsers don't coalesce or block them.
            await Task.Delay(300);
        }

        return labels.Count > 0;
    }

    public Task PrintAsync(LabelFile label, string? printerName)
    {
        LabelInterop.Print(label.ContentType, Convert.ToBase64String(label.Bytes));
        return Task.CompletedTask;
    }

    public Task OpenWithSystemDefaultAsync(LabelFile label) => SaveAsync(label);
}

[System.Runtime.Versioning.SupportedOSPlatform("browser")]
internal static partial class LabelInterop
{
    [JSImport("globalThis.asERPLabels.download")]
    public static partial void Download(string fileName, string contentType, string base64);

    [JSImport("globalThis.asERPLabels.print")]
    public static partial void Print(string contentType, string base64);
}
#endif
