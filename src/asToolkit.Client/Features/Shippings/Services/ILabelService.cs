namespace asToolkit.Client.Features.Shippings.Services;

/// <summary>A fetched shipping label ready for a platform action (save/download/print/open).</summary>
public sealed record LabelFile(byte[] Bytes, string ContentType, string FileName);

/// <summary>Label actions the current platform supports. Drives which buttons the UI shows.</summary>
[Flags]
public enum LabelCapabilities
{
    None = 0,

    /// <summary>Save via a native file-save dialog (Desktop).</summary>
    Save = 1,

    /// <summary>Download via the browser (WASM).</summary>
    Download = 2,

    /// <summary>Print directly (Desktop-Windows spooler, or the browser's print dialog).</summary>
    Print = 4,

    /// <summary>A named printer can be picked client-side (Desktop-Windows only — the
    /// browser's print dialog owns printer selection on WASM).</summary>
    PickPrinter = 8,
}

/// <summary>
/// Platform-specific label handling: fetches the label bytes from the API and executes
/// the save/download/print/open action the platform supports.
/// </summary>
public interface ILabelService
{
    /// <summary>Actions the current platform supports.</summary>
    LabelCapabilities Capabilities { get; }

    /// <summary>Downloads the label of a shipment from the API.</summary>
    Task<LabelFile> FetchLabelAsync(Guid shippingId, CancellationToken ct = default);

    /// <summary>Installed printer names; empty when the platform cannot enumerate printers.</summary>
    Task<IReadOnlyList<string>> GetPrinterNamesAsync();

    /// <summary>Saves via the platform's file-save mechanism. Returns false when the user
    /// cancelled the picker.</summary>
    Task<bool> SaveAsync(LabelFile label);

    /// <summary>Prints the label; <paramref name="printerName"/> null means the default printer.</summary>
    Task PrintAsync(LabelFile label, string? printerName);

    /// <summary>Opens the label with the system's default application for its content type.</summary>
    Task OpenWithSystemDefaultAsync(LabelFile label);

    /// <summary>Runs a remembered label action, falling back to
    /// <see cref="OpenWithSystemDefaultAsync"/> when the platform lacks the capability.</summary>
    Task ExecuteAsync(LabelFile label, LabelActionPreference pref);
}
